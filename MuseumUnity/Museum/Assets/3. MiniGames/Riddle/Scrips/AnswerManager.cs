using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class AnswerManager : MonoBehaviour
{
    private string answerRiddle;
    private bool start = false;
    private int tokenValue = 0;
    [SerializeField] GameObject letterPrefab;
    [SerializeField] TMP_Text riddleTextbox;
    [SerializeField] GameObject answerFill;
    [SerializeField] private GameObject startImage;
    [SerializeField] private GameObject endImage;
    [SerializeField] private GameObject floorProjection;

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
    private int count = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        for (int t = 0; t < riddles.Length; t++)
        {
            Riddle tmp = riddles[t];
            int r = UnityEngine.Random.Range(t, riddles.Length);
            riddles[t] = riddles[r];
            riddles[r] = tmp;
        }
    }
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
            StartCoroutine(EndImage());
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

    private void prepareMinigame(int n)
    {
        nCorrectLetters = 0;
        //int randomN = UnityEngine.Random.Range(0, riddles.Length);
        riddleTextbox.text = riddles[n].riddle;
        nLetterAnswer = riddles[n].answer.Length;
        letters = new List<GameObject>();
        char[] tmpC = new Char[26];
        for (int i = 65; i < 65 + 26; i++)
        {
            tmpC[i - 65] = (char)i;
        }
        foreach (char a in riddles[n].answer)
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

    public void StartMinigame(int n)
    {
        floorProjection.SetActive(true);
        tokenValue = n;
        start = true;
        StartCoroutine(StartImage());
        
        prepareMinigame(count);
        count++;
    }


    IEnumerator StartImage()
    {
        startImage.SetActive(true);
        yield return new WaitForSeconds(5f);
        startImage.SetActive(false);
    }

    IEnumerator EndImage()
    {
        if(count%2 != 0)
        {
            StartMinigame(tokenValue);
        }
        else
        {
            endImage.SetActive(true);
            yield return new WaitForSeconds(3f);
            endImage.SetActive(false);
            TokenManager.Instance.NewTokenHalf(tokenValue);
            //triggero qua un dialogue
            MinigameManager.Instance.MinigameEnd();
            floorProjection.SetActive(false);
            gameObject.SetActive(false);
        }
        
    }
}
