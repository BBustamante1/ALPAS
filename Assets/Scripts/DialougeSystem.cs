using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DialougeSystem : MonoBehaviour
{
    //Quest UI
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject questText, questHomeText;
    //
    private int showEndSign, endChapter = 0;
    public GameObject canvasTransition;
    private int disableCondition = 0;
    [SerializeField] private int currChapter;
    private Animator animatorChar;
    [SerializeField] private GameObject signHomeBTN;
    [SerializeField] private GameObject[] charactersArray;
    [SerializeField] private TextAsset loadGlobalsJSON;
    private DialougeVariables dialougeVariables;
    private string currNPC;
    public GameObject nameTag;
    private static DialougeSystem instance;
    private Story currentStory;
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine = false;
    public static bool changeDialog;
    public bool submitButtonPressedThisFrame = false;
    [SerializeField] private float typingSpeed = 0.04f;
    public bool dialougeIsPlaying { get; set; }
    public bool showQuestPanel { get; set; }

    public bool uiActive { get; set; }
    [Header("Dialouge UI")]
    [SerializeField] private GameObject dialougePanel;
    [SerializeField] private TextMeshProUGUI dialougeText;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TMP_Text displayNameText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private const string SPEAKER_TAG = "speaker";
    private const string AUDIO_TAG = "audio";
    private string audioClipName;
    void Start()
    {
        showQuestPanel = false;
        uiActive = true;
        submitButtonPressedThisFrame = false;
        dialougeIsPlaying = true;
        dialougePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
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

    public static DialougeSystem GetInstance ()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialougeIsPlaying && !uiActive)
        {
            questPanel.SetActive(false);
            HandleTags(currentStory.currentTags);
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("NPC"))
            {
                Renderer renderer = gameObject.GetComponent<Renderer>();
                if (!renderer.isVisible && renderer.name == currNPC)
                {
                    StartCoroutine(ExitDialougeMode());
                }
            }
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
                FindObjectOfType<AudioManager>().Stop();
                DisableTalkingAnimation();
                submitButtonPressedThisFrame = false;
                ContinueStory();
            }
        }
        else
        {
            DisableTalkingAnimation();
            if (showQuestPanel)
            {
                if (endChapter == 0)
                {
                    questPanel.SetActive(true);
                    if (showEndSign != 1)
                    {
                        questText.SetActive(true);
                        questHomeText.SetActive(false);
                    }
                    else
                    {
                        questText.SetActive(false);
                        questHomeText.SetActive(true);
                    }
                }
                else
                {
                    questPanel.SetActive(false);
                }
            }
        }
    }


    public void EnterDialougeMode(TextAsset inkJSON, bool nothomeBTN)
    {
        audioClipName = null;
        currentStory = new Story(inkJSON.text);
        dialougeIsPlaying = true;
        submitButtonPressedThisFrame = false;
        dialougePanel.SetActive(true);
        if (nothomeBTN) nameTag.SetActive(true);
        dialougeVariables.StartListening(currentStory);
        ContinueStory();
        //0.5f
        //yield return new WaitForSeconds(0.1f);
    }

    private void ContinueStory ()
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
            //Quests
            //Get Ink Variable 
            int isabelState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("TiyaIsabelState")).value;
            showEndSign = ((IntValue)DialougeSystem.GetInstance().GetVariableState("showEndSign")).value;
            endChapter = ((IntValue)DialougeSystem.GetInstance().GetVariableState("endChapter")).value;
            //Events
            if (isabelState == 2 && disableCondition == 0)
            {
                OpenEnterMainHall.handPointer.SetActive(true);
                OpenEnterMainHall.canOpenDoor = true;
                disableCondition = 1;
            }
            if (endChapter == 1)
            {
                StartCoroutine(LoadSceneAsync());
            }
            InteractOrder.GetInstance().setExclamationMark();
            if (currChapter == 2) StartTiyagoMsg.GetInstance().StartMovement();
            if (showEndSign == 1)
            {
                signHomeBTN.SetActive(true);
            }
            //EndDialouge
            StartCoroutine(ExitDialougeMode());
        }
    }

    IEnumerator LoadSceneAsync()
    {
        Animator animator = canvasTransition.GetComponent<Animator>();
        animator.SetTrigger("Trigger");
        yield return new WaitForSeconds(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(operation.progress);
            yield return null;
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialougeText.text = line;
        dialougeText.maxVisibleCharacters = 0;
        continueIcon.SetActive(false);
        canContinueToNextLine = false;
        HideChoices();
        yield return new WaitForSeconds(0.1f);
        if (audioClipName != null)
        {
            FindObjectOfType<AudioManager>().Play(audioClipName);
        }
        for (int i = 0; i < charactersArray.Length; i++)
        {
            if (currNPC == charactersArray[i].name)
            {
                if (charactersArray[i].GetComponent<Animator>() != null)
                {
                    animatorChar = charactersArray[i].GetComponent<Animator>();
                    animatorChar.SetBool("Trigger", true);
                    break;
                }
            }
        }
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
        DisplayChoices();
        continueIcon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    public void DisableTalkingAnimation()
    {
        for (int i = 0; i < charactersArray.Length; i++)
        {
            if (charactersArray[i].GetComponent<Animator>() != null)
            {
                animatorChar = charactersArray[i].GetComponent<Animator>();
                animatorChar.SetBool("Trigger", false);
            }
        }
    }

    public IEnumerator ExitDialougeMode()
    {
        currNPC = null;
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<AudioManager>().Stop();
        audioClipName = null;
        DisableTalkingAnimation();
        dialougeVariables.StartListening(currentStory);
        dialougeIsPlaying = false;
        dialougePanel.SetActive(false);
        dialougeText.text = "";
        nameTag.SetActive(false);
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More Choices" + currentChoices.Count);
        }
        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropirately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey) 
            {
                case SPEAKER_TAG:
                    currNPC = tagValue;
                    displayNameText.text = currNPC;
                    break;
                case AUDIO_TAG:
                    audioClipName = tagValue;
                    break;
                default:
                    Debug.LogWarning("no tag");
                    break;
            }
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            FindObjectOfType<AudioManager>().Stop();
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
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
