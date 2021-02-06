using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableDialogue : MonoBehaviour
{
    [SerializeField] bool IsDoor = false;
    [SerializeField] GameObject[] dialogues;
    [SerializeField] int selector = 0;
    [SerializeField] GameObject firstTokenObj;
    [SerializeField] GameObject secondTokenObj;


    public void dialogue()
    {
        if(IsDoor)
        {
            updateSelector();
        }
        if(dialogues[selector].GetComponent<DialogueTrigger>() != null )
            dialogues[selector].GetComponent<DialogueTrigger>().TriggerDialogue();
        if (dialogues[selector].GetComponent<StartingRoomDialogue>() != null)
            dialogues[selector].GetComponent<StartingRoomDialogue>().NextDialogue();



    }
    
    public void setSelector(int n)
    {
        selector = n;
    }

    public void updateSelector()
    {
        bool[] tmp = TokenManager.Instance.GetHalfTokens();
        int tmp2 = 0;
        if (tmp[0])
        {
            firstTokenObj.SetActive(true);
            tmp2++;
        }
        if (tmp[1])
        {
            secondTokenObj.SetActive(false);
            tmp2++;
        }
            
        selector = tmp2;
    }

}
