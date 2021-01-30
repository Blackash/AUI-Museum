using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public Sprite spriteLeft;

    public Sprite spriteRight;

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
        DialogueManager.Instance.StartDialogue(dialogue, spriteLeft, spriteRight);
        StartCoroutine(DialogueCoroutine(dialogue));
    }

    public void NextQuestion()
    {
        DialogueManager.Instance.DisplayNextSentence();
    }

    public void ResetQuestion()
    {
        TriggerDialogue();
    }


    IEnumerator DialogueCoroutine(Dialogue d)
    {
        for(int i=0; i<d.sentences.Length; i++)
        {
            yield return new WaitForSeconds(d.time[i]);
            NextQuestion();
        }


    }



}
