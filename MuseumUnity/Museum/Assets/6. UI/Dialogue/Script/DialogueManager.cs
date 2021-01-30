using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    private Queue<string> sentences =  new Queue<string>();

    public Text nameText;
    public Text dialogueText;
    public Image leftChar;
    public Image rightChar;
    public Image arrow;
    public GameObject dialogueUI;
    public bool isMinigame = false;


    void Start()
    {
        Debug.Log(sentences);
        //sentences = new Queue<string>();
        Debug.Log(sentences);
        if (!isMinigame)
            dialogueUI.SetActive(false);
    }


    public void StartDialogue(Dialogue dialogue, Sprite leftCharS, Sprite rightCharS)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        leftChar.GetComponent<Image>().sprite = leftCharS;
        rightChar.GetComponent<Image>().sprite = rightCharS;

        dialogueUI.SetActive(true);

        nameText.text = dialogue.name;
        Debug.Log(sentences);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        { 
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End Conversation");
        if (!isMinigame)
        {
            FindObjectOfType<PlayerMovement>().SblockMovement();
            dialogueUI.SetActive(false);
        }
    }
    

}
