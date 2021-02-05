using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoomDialogue : MonoBehaviour
{
    [SerializeField] DialogueTrigger[] LongDialogue;
    [SerializeField] private bool isStartingDialogue = false;
    int count = 0;
    private bool oneTime = false;
    private void Start()
    {
        
    }

    private void Update()
    {
        if(!oneTime && isStartingDialogue)
        {
            oneTime = true;
            NextDialogue();
        }
        
    }

    public void NextDialogue()
    {
        if (count == LongDialogue.Length)
            return;
        LongDialogue[count].TriggerDialogue();
        count++;
    }
}
