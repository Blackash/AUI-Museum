using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AnswersBossManager answerManager;
    [SerializeField] DialogueTrigger questions;
    [SerializeField] Image hourglassImage;
    [SerializeField] Sprite[] hourglassImageList;
    private bool reset;
    private int currentQuestion;
    private int currentCount = 0;

    void Start()
    {
        
        answerManager.nextQuestion();
        currentQuestion = 0;
        StartCoroutine(Timer(currentCount));
        questions.ResetQuestion();
    }


    public void Answer(int buttonN)
    {
        currentCount++;
        StartCoroutine(Timer(currentCount));
        if (answerManager.checkAnswer(buttonN) && buttonN>-1)
        {
            //reset timer
            answerManager.nextQuestion();
            currentQuestion++;
            questions.NextQuestion();
        }
        else
        {
            //reset timer
            answerManager.WrongAnswer();
            answerManager.nextQuestion();
            currentQuestion = 0;
            questions.ResetQuestion();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer(int count)
    {
        hourglassImage.sprite = hourglassImageList[0];
        int tmp = currentQuestion;
        for(int i=1; i<16; i++)
        {
            yield return new WaitForSeconds(1f);
            
            if (currentCount > count)
                i = 20;
            else
                hourglassImage.sprite = hourglassImageList[i];
            if (i == 15)
                Answer(-1);
        }
    }


    public void FinishGame()
    {
        Debug.Log("you win");
    }
}
