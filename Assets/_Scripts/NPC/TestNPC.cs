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
            DialogueManager.Instance.DisplayNextSentence(DialogueTrigger.Instance.dialogue[DialogueManager.Instance.actualDialogue].whoSpeak);
            return;
        }

        //enable NPC dialogue box
        //DialogueManager.Instance.npcDialogueBox.SetActive(true);

        if (DialogueTrigger.Instance.dialogue[DialogueManager.Instance.actualDialogue].whoSpeak == WhoSpeak.NPC)
        {
            DialogueManager.Instance.npcDialogueBox.SetActive(true);
        }
        else if (DialogueTrigger.Instance.dialogue[DialogueManager.Instance.actualDialogue].whoSpeak == WhoSpeak.PLAYER)
        {
            DialogueManager.Instance.protagonistDialogueBox.SetActive(true);
        }
        else
        {
            Debug.Log("I don't  know who speaks in Interaction() in TestNPCs");
        }

        // Trigger dialogue
        DialogueManager.Instance.GetComponent<DialogueTrigger>().TriggerDialogue();

        if (DialogueManager.Instance.actualDialogue < DialogueTrigger.Instance.dialogue.Length)
        {
            DialogueManager.Instance.actualDialogue++;
        }

    }

    public void FirstInteraction()
    {

    }

}
