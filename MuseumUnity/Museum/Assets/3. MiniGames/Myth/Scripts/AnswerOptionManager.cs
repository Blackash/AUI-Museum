using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswerOptionManager : Singleton<AnswerOptionManager>
{

    [SerializeField] Button[] answersButtons;
    [SerializeField] string[] answers = new string[4];
    [SerializeField] [Range(1, 4)] int correct;
    void Start()
    {
           for(int i=0;i<answers.Length;i++)
        {
            answersButtons[i].gameObject.GetComponentInChildren<Text>().text = answers[i];
            if(i == correct -1)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
