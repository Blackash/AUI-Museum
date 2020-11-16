using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public Sprite spriteLeft;
    public void TriggerDialogue ()
    {
        DialogueManager.Instance.StartDialogue(dialogue, null, spriteLeft);
    }

    


}
