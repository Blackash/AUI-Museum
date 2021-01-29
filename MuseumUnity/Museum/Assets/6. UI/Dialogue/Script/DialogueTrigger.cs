using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public Sprite spriteLeft;

    public bool isMinigame = false;

    private bool dialoguetrigger = false;
    public void Update()
    {
        if (isMinigame && !dialoguetrigger)
        {
            dialoguetrigger = true;
            //TriggerDialogue();
        }
    }
    public void TriggerDialogue ()
    {
        DialogueManager.Instance.StartDialogue(dialogue, null, spriteLeft);
    }

    public void NextQuestion()
    {
        DialogueManager.Instance.DisplayNextSentence();
    }

    public void ResetQuestion()
    {
        TriggerDialogue();
    }

    


}
