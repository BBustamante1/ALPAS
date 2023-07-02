using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class NPCDialog : MonoBehaviour
{
    private string currNPC;
    private string scriptNPC;
    private static NPCDialog instance;
    private Story npcStory;
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine = false;
    private bool submitButtonPressedThisFrame = false;
    [SerializeField] private float typingSpeed = 0.04f;
    public bool dialougeIsPlaying { get; private set; }
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [Header("Dialouge UI")]
    [SerializeField] private GameObject dialougePanel;
    [SerializeField] private TextMeshProUGUI dialougeText;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TMP_Text displayNameText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private const string SPEAKER_TAG = "speaker";
    void Start()
    {
        dialougeIsPlaying = false;
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
    
    public static NPCDialog GetInstance ()
    {
        return instance;
    }

    public void EnterScript()
    {
        submitButtonPressedThisFrame = false;
        NPCDialog.GetInstance().EnterDialougeMode(inkJSON);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialougeSystem.changeDialog)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                submitButtonPressedThisFrame = true;
            }
            if (!dialougeIsPlaying)
            {
                return;
            }

            if (canContinueToNextLine && npcStory.currentChoices.Count == 0 && submitButtonPressedThisFrame)
            {
                submitButtonPressedThisFrame = false;
                ContinueStory();
            }
        }
    }

    public void EnterDialougeMode(TextAsset inkJSON)
    {
        npcStory = new Story(inkJSON.text);
        dialougeIsPlaying = true;
        dialougePanel.SetActive(true);
        ContinueStory();
    }

    private void ContinueStory ()
    {
        if (displayLineCoroutine != null)
        {
            StopCoroutine(displayLineCoroutine);
        } else
        {
            StartCoroutine(ExitDialougeMode());
        }
        displayLineCoroutine = StartCoroutine(DisplayLine(npcStory.Continue()));
        HandleTags(npcStory.currentTags);
    }

    private IEnumerator DisplayLine(string line)
    {
        dialougeText.text = line;
        dialougeText.maxVisibleCharacters = 0;
        continueIcon.SetActive(false);
        canContinueToNextLine = false;
        HideChoices();
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
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private IEnumerator ExitDialougeMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialougeIsPlaying = false;
        dialougePanel.SetActive(false);
        dialougeText.text = "";
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = npcStory.currentChoices;
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
                    displayNameText.text = tagValue;
                    break;
                default:
                    Debug.LogWarning(tag);
                    break;
            }
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            npcStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }
}
