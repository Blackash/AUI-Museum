using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;
    public Image leftChar;
    public Image rightChar;
    public Image arrow;
    public GameObject dialogueUI;



    void Start()
    {
        sentences = new Queue<string>();
        dialogueUI.SetActive(false);
    }


    public void StartDialogue(Dialogue dialogue, Sprite leftCharS, Sprite rightCharS)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        leftChar.GetComponent<Image>().sprite = leftCharS;
        rightChar.GetComponent<Image>().sprite = rightCharS;

        dialogueUI.SetActive(true);

        nameText.text = dialogue.name;

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

        dialogueUI.SetActive(false);
    }
    

}
