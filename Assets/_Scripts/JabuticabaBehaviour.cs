using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabuticabaBehaviour : Item
{

    public bool firstInteraction = true;

    public Animator globalLightAnimator;

    public override void Interaction()
    {
        if (firstInteraction || DialogueManager.Instance.conversationIsHappening)
        {
            if (firstInteraction)
            {
                firstInteraction = false;
                //GameManager.Instance.globalLight.color = Color.white;
                //GameManager.Instance.globalLight.intensity = 1.2f;

                globalLightAnimator.SetBool("InPastTime", true);

                DialogueManager.Instance.actualDialogue = 2;
            }
            

            // If the conversation already started and we just need to change the sentences
            if (DialogueManager.Instance.conversationIsHappening)
            {
                DialogueManager.Instance.DisplayNextSentence(DialogueTrigger.Instance.dialogue[DialogueManager.Instance.actualDialogue].whoSpeak);
                //print("INTERACTION WhoSpeak: " + DialogueTrigger.Instance.dialogue[DialogueManager.Instance.actualDialogue].whoSpeak);

                if (DialogueTrigger.Instance.dialogue[DialogueManager.Instance.actualDialogue].sentences.Length == DialogueManager.Instance.actualDialogue)
                {
                    DialogueManager.Instance.EndDialogue();
                    DialogueManager.Instance.actualSentence = 0;
                    DialogueManager.Instance.conversationIsHappening = false;
                }

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

        }
    }
}
