using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingRoomDialogue : MonoBehaviour
{
    [SerializeField] DialogueTrigger[] LongDialogue;
    [SerializeField] private bool isStartingDialogue = false;
    [SerializeField] private bool isEndingDialogue = false;
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
        {
            if (!isEndingDialogue)
            {
                return;
            }
            SceneManager.LoadScene("EndDemoScene");
            return;

        }
        LongDialogue[count].TriggerDialogue();
        count++;
    }
}
