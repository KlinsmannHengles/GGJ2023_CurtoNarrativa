using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    public static DialogueTrigger Instance { get; private set; }

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

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue[DialogueManager.Instance.actualDialogue]);
    }
}
