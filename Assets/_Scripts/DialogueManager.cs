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

    public PlayerMovement playerMovement;

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

        playerMovement.moveSpeed = 0f;

        conversationIsHappening = true;

        Debug.Log("Starting conversation with " + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        // CHANGE IT TO A IF WITH THE TWO DIALOGUE BOXES
        DialogueManager.Instance.npcDialogueText.text = sentence;
    }

    void EndDialogue()
    {
        // CHANGE IT TO A IF WITH THE TWO DIALOGUE BOXES
        DialogueManager.Instance.npcDialogueBox.SetActive(false);

        conversationIsHappening = false;

        playerMovement.moveSpeed = 5f;

        Debug.Log("End of conversation");
    }

}
