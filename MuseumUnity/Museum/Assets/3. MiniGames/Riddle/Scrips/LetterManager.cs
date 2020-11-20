using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LetterManager : MonoBehaviour
{
    
    [SerializeField] private TMP_Text letter;
    [SerializeField] private Image geroglipth;
    private char letterChar;
    Sprite gImage;

    public void correctLetter(char a, Sprite image)
    {
        letterChar = a;
        gImage = image;
    }

    public bool tryLetter(char a)
    {
        if(a == letterChar)
        {
            letter.text = letterChar+"";
            geroglipth.sprite = gImage;
            return true;
        }
        return false;
    }
}
