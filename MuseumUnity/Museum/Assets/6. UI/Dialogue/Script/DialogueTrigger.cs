using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public Sprite spriteLeft;

    public Sprite spriteRight;

    public bool startMiniGame = false;
    public int tokenValue = 1;

   [SerializeField] MiniGames miniGame;

    public bool isMinigame = false;

    public bool isPartOfBigDialogue = false;

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
        if (!isMinigame)
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

            if (!(d.sound[i].Equals("None")))
                FindObjectOfType<DialogueSoundManager>().Play(d.sound[i]);
            yield return new WaitForSeconds(d.time[i]);
            NextQuestion();
        }
        if (startMiniGame)
            MinigameManager.Instance.StartMinigame(miniGame,tokenValue);
        if (isPartOfBigDialogue)
            GetComponentInParent<StartingRoomDialogue>().NextDialogue();
    }



}
