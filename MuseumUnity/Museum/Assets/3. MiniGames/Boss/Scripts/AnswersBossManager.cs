using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswersBossManager : Singleton<AnswersBossManager>
{
    
    [Serializable]
    private class answersBoss
    {
         
         public string[] answers = new string[4];
         public int correct;
    }

    [SerializeField] private answersBoss[] AnswerLists;
    [SerializeField] private  Button[] answersButtons = new Button[4];
    
    private int questionNumber = 0;

    public void nextQuestion()
    {
        if (questionNumber == AnswerLists.Length)
        {
            FindObjectOfType<BossManager>().FinishGame();
            return;
                }
        for (int i = 0; i < 4; i++)
        {
            answersButtons[i].gameObject.GetComponentInChildren<Text>().text = AnswerLists[questionNumber].answers[i];
            if (i == AnswerLists[questionNumber].correct - 1)
            {
                ColorBlock colors = answersButtons[i].colors;

                colors.pressedColor = new Color32(15, 238, 25, 255);
                answersButtons[i].colors = colors;
            }
            else
            {
                ColorBlock colors = answersButtons[i].colors;

                colors.pressedColor = new Color32(225, 0, 0, 255);
                answersButtons[i].colors = colors;
            }
        }
        
        questionNumber++;
        Debug.Log(questionNumber);
    }

    public void WrongAnswer()
    {
        Debug.Log(questionNumber);
        questionNumber = 0;
    }


    public bool checkAnswer(int tmp)
    {
        Debug.Log(questionNumber);
        return tmp == AnswerLists[questionNumber - 1].correct;
    }
}
