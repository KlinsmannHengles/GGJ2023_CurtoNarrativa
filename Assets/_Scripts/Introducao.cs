using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Introducao : MonoBehaviour
{

    public TextMeshProUGUI pressE;

    public GameObject telefone;

    public bool final = false;

    public GameObject choro;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown("e") && DialogueManager.Instance.actualDialogue < DialogueTrigger.Instance.dialogue.Length)
       {
            telefone.SetActive(false);
            pressE.text = "Press E to contiune";
             // If the conversation already started and we just need to change the sentences
            if (DialogueManager.Instance.conversationIsHappening)
            {
                DialogueManager.Instance.DisplayNextSentence(DialogueTrigger.Instance.dialogue[DialogueManager.Instance.actualDialogue].whoSpeak);
                //return;
            }

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
            
            DialogueManager.Instance.actualDialogue++;
       } else if (Input.GetKeyDown("e") && DialogueManager.Instance.actualDialogue == DialogueTrigger.Instance.dialogue.Length && final == false){
            final = true;
            DialogueManager.Instance.EndDialogue();
            choro.SetActive(true);
       }
    }

    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(3f);
        pressE.text = "Pressione E para atender";
        
    }

}
