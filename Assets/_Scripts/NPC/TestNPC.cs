using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : GenericNPCBehaviour
{
    public override void Interaction()
    {
        // If the conversation already started and we just need to change the sentences
        if (DialogueManager.Instance.conversationIsHappening)
        {
            DialogueManager.Instance.DisplayNextSentence();
            return;
        }

        //enable NPC dialogue box
        DialogueManager.Instance.npcDialogueBox.SetActive(true);

        // Trigger dialogue
        DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();

        // Display sentence
        DialogueManager.Instance.DisplayNextSentence();

    }

    public void FirstInteraction()
    {

    }

}
