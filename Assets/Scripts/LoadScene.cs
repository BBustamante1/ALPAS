using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] public TMP_Text chapName;
    public GameObject loadingScreen;
    public float transitionTime;
    public GameObject canvasTransition;
    private int indexScene;
    [SerializeField] private TextAsset loadGlobalsJSON;
    [SerializeField] private TextAsset chapterPlotJSON;
    private DialougeVariables dialougeVariables;
    private static LoadScene instance;
    private Story currentStory;
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine = false;
    public bool submitButtonPressedThisFrame = false;
    [SerializeField] private float typingSpeed = 0.04f;
    public bool dialougeIsPlaying { get; private set; }
    [Header("Dialouge UI")]
    [SerializeField] private GameObject dialougePanel;
    [SerializeField] private TextMeshProUGUI dialougeText;
    [Header("Choices UI")]
    private const string SPEAKER_TAG = "speaker";

    private void Update()
    {
        HandleTags(currentStory.currentTags);
        if (dialougeIsPlaying)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                submitButtonPressedThisFrame = true;
            }
            if (!dialougeIsPlaying)
            {
                return;
            }

            if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && submitButtonPressedThisFrame)
            {
                submitButtonPressedThisFrame = false;
                ContinueStory();
            }
        }
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        Animator animator = canvasTransition.GetComponent<Animator>();
        animator.SetTrigger("Trigger");
        yield return new WaitForSeconds(transitionTime);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(operation.progress);
            yield return null;
        }
    }

    void Start()
    {
        submitButtonPressedThisFrame = false;
        dialougeIsPlaying = false;
        dialougePanel.SetActive(false);
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialouge System");
        }
        instance = this;

    }

    private void Awake()
    {
        dialougeVariables = new DialougeVariables(loadGlobalsJSON);
    }

    public static LoadScene GetInstance()
    {
        return instance;
    }


    public IEnumerator EnterDialougeMode(int chapIndex, string chaptName)
    {
        chapName.text = chaptName;
        Ink.Runtime.Object obj = new Ink.Runtime.IntValue(chapIndex);
        LoadScene.GetInstance().SetVariableState("ChapterPlot", obj);
        currentStory = new Story(chapterPlotJSON.text);
        indexScene = chapIndex;
        submitButtonPressedThisFrame = false;
        dialougePanel.SetActive(true);
        dialougeVariables.StartListening(currentStory);
        ContinueStory();
        yield return new WaitForSeconds(0.5f);
        dialougeIsPlaying = true;
    }

    private void ContinueStory()
    {
        //(string)currentStory.["TiyaIsabelState"]
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            HandleTags(currentStory.currentTags);
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
        }
        else
        {
            ExitDialougeMode();
            StartCoroutine(LoadSceneAsync(indexScene));
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialougeText.text = line;
        dialougeText.maxVisibleCharacters = 0;
        canContinueToNextLine = false;
        yield return new WaitForSeconds(0.1f);
        foreach (char letter in line.ToCharArray())
        {
            if (submitButtonPressedThisFrame)
            {
                submitButtonPressedThisFrame = false;
                dialougeText.maxVisibleCharacters = line.Length;
                break;
            }
            dialougeText.maxVisibleCharacters++;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinueToNextLine = true;
        yield return new WaitForSeconds(0.5f);
    }

    public void ExitDialougeMode()
    {
        dialougeVariables.StartListening(currentStory);
        dialougeIsPlaying = false;
        dialougePanel.SetActive(false);
        dialougeText.text = "";
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropirately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    break;
                default:
                    Debug.LogWarning(tag);
                    break;
            }
        }
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialougeVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }

    public void SetVariableState(string variableName, Ink.Runtime.Object variableValue)
    {
        if (dialougeVariables.variables.ContainsKey(variableName))
        {
            dialougeVariables.variables.Remove(variableName);
            dialougeVariables.variables.Add(variableName, variableValue);
        }
        else
        {
            Debug.LogWarning("Tried to update variable that wasn't initialized by globals.ink: " + variableName);
        }
    }
}
