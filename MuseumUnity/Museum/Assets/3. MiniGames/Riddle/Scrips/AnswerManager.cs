using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class AnswerManager : MonoBehaviour
{
    private string answerRiddle;
    private bool start = false;

    [SerializeField] GameObject letterPrefab;
    [SerializeField] TMP_Text riddleTextbox;
    [SerializeField] GameObject answerFill;


    [System.Serializable]
    public class Riddle
    {
        [TextArea(15, 20)] public string riddle;
        [SerializeField] public string answer;
    }
    public Riddle [] riddles;
    public Sprite[] alpha;

    List<GameObject> letters;
    private int nCorrectLetters;
    private int nLetterAnswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
            return;
        if (nCorrectLetters == nLetterAnswer)
        {
            start = false;
            
            for(int i=0; i<letters.Count;i++)
            {
                Destroy(letters[i]);
            }
            letters.Clear();
            gameObject.SetActive(false);
            return; //victory
        }
            
        string tmp = DetectPressedKeyOrButton();
        if(tmp != null)
        {
            char key = tmp[0];
            if (letters[nCorrectLetters].GetComponent<LetterManager>().tryLetter(key))
            {
                nCorrectLetters++;
            }

        }


    }

    public string DetectPressedKeyOrButton()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                return kcode.ToString();


        }
        return null;
    }

    /* KeyCode tempKeyCode;
     KeyCode Forward1;

     public void OnClick()
     {
         Forward1 = tempKeyCode;
     }

     void OnGUI()
     {
         Event e = Event.current;
         if (e.isKey)
         {
             tempKeyCode = e.keyCode;
             Debug.Log(tempKeyCode);
         }

     }*/

    private void prepareMinigame()
    {
        nCorrectLetters = 0;
        int randomN = UnityEngine.Random.Range(0, riddles.Length);
        riddleTextbox.text = riddles[randomN].riddle;
        nLetterAnswer = riddles[randomN].answer.Length;
        letters = new List<GameObject>();
        char[] tmpC = new Char[26];
        for (int i = 65; i < 65 + 26; i++)
        {
            tmpC[i - 65] = (char)i;
        }
        foreach (char a in riddles[randomN].answer)
        {
            GameObject tmp;
            tmp = Instantiate(letterPrefab, new Vector3(0, 0, 0), Quaternion.identity, answerFill.transform);

            for (int i = 0; i < tmpC.Length; i++)
            {
                if (tmpC[i] == a)
                {
                    tmp.GetComponent<LetterManager>().correctLetter(a, alpha[i]); //TODO: aggiungere immagine giusta
                }
            }

            letters.Add(tmp);
        }

    }

    public void StartMinigame()
    {
        start = true;
        prepareMinigame();
    }
}
