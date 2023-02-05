using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance { get; private set; }

    private Queue<string> sentences;

    public bool conversationIsHappening = false;

    public int actualDialogue = 0;
    public int actualSentence = 0;

    public PlayerMovement playerMovement;

    public Animator animator_BottonBox;
    public Animator animator_UpBox;

    [Header("DialogueUI")]
    public GameObject protagonistDialogueBox;
    public GameObject npcDialogueBox;

    public TextMeshProUGUI protagonistDialogueText;
    public TextMeshProUGUI npcDialogueText;


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        /*// I can change it to make just open the botton or the up
        animator_BottonBox.SetBool("IsOpen", true);
        animator_UpBox.SetBool("IsOpen", true);*/

        if (dialogue.whoSpeak == WhoSpeak.NPC)
        {
            animator_UpBox.SetBool("IsOpen", true);
        } else if (dialogue.whoSpeak == WhoSpeak.PLAYER)
        {
            animator_BottonBox.SetBool("IsOpen", true);
        } else
        {
            Debug.Log("I don't  know who speaks in StartDialogue() in DialogueManager()");
        }

        playerMovement.moveSpeed = 0f;

        conversationIsHappening = true;

        Debug.Log("Starting conversation with " + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(dialogue.whoSpeak);
    }

    public void DisplayNextSentence(WhoSpeak _whoSpeak)
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(_whoSpeak, sentence));
    }

    IEnumerator TypeSentence (WhoSpeak _whoSpeak, string sentence)
    {
        if (_whoSpeak == WhoSpeak.NPC)
        {
            npcDialogueText.text = "";
        }
        else if (_whoSpeak == WhoSpeak.PLAYER)
        {
            protagonistDialogueText.text = "";
        }
        else
        {
            Debug.Log("I don't know who is speaking in TypeSentence()");
        }


        foreach (char letter in sentence.ToCharArray())
        {
            //Debug.Log("WhoSpeak: " + _whoSpeak);
            //Debug.Log("Sentence: " + sentence);
            if (_whoSpeak == WhoSpeak.NPC)
            {
                npcDialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            } else if (_whoSpeak == WhoSpeak.PLAYER)
            {
                protagonistDialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            } else
            {
                Debug.Log("I don't know who is speaking in TypeSentence()");
            }
        }
        actualSentence++;
    }

    public void EndDialogue()
    {
        // Disable both Dialogue Boxes
        DialogueManager.Instance.npcDialogueBox.SetActive(false);
        DialogueManager.Instance.protagonistDialogueBox.SetActive(false);

        // I CAN CHANGE IT TO CHANGE JUST THE BOTTON OR THE UP
        animator_BottonBox.SetBool("IsOpen", false);
        animator_UpBox.SetBool("IsOpen", false);

        conversationIsHappening = false;

        actualSentence = 0;

        playerMovement.moveSpeed = 5f;

        Debug.Log("End of conversation");
    }

}
