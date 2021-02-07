using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswerOptionManager : Singleton<AnswerOptionManager>
{

    [SerializeField] Button[] answersButtons;
    [SerializeField] string[] answers = new string[4];
    [SerializeField] [Range(1, 4)] int correct;
    [SerializeField] DialogueTrigger failedDialogue;
    [SerializeField] StartingRoomDialogue endDialogue;
    void Start()
    {
           
    }



    private void prepareMinigame()
    {

        for (int i = 0; i < answers.Length; i++)
        {
            answersButtons[i].gameObject.GetComponentInChildren<Text>().text = answers[i];
            if (i == correct - 1)
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


    }

    public void StartMinigame()
    {
        //floorProjection.SetActive(true);
        //tokenValue = n;
        //start = true;
        //StartCoroutine(StartImage());

        prepareMinigame();
    }


    /*IEnumerator StartImage()
    {
        startImage.SetActive(true);
        yield return new WaitForSeconds(5f);
        startImage.SetActive(false);
    }*/

    /*IEnumerator EndImage()
    {
        if ()
        {
            StartMinigame();
        }
        else
        {
            //endImage.SetActive(true);
            yield return new WaitForSeconds(3f);
            //endImage.SetActive(false);
            //TokenManager.Instance.NewTokenHalf(tokenValue);
            //triggero qua un dialogue
            
            //floorProjection.SetActive(false);
            gameObject.SetActive(false);
        }

    }*/

    public void clickAnswer(int n)
    {
        if(n == correct)
        {
            End();
        }
        else
        {
            FailedAnswer();
        }
    }


    private void End()
    {
        //trigger end big dialogue
        //trigger after that the scene change
        MinigameManager.Instance.MinigameEnd();
        endDialogue.NextDialogue();
        gameObject.SetActive(false);
    }

    private void FailedAnswer()
    {
        //trigger failed dialogue
        MinigameManager.Instance.MinigameEnd();
        failedDialogue.TriggerDialogue();
        gameObject.SetActive(false);
    }

}
