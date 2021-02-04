using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DressUpManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int correctDress;
    private int numberOfPanels;
    [SerializeField] private GameObject pyramid;
    [SerializeField] private GameObject warDrobe;
    [SerializeField] private GameObject human;
    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private string[] descriptionText = new string[6];
    [SerializeField] private Text Description;
    [SerializeField] private SocialClass socialClass;
    [SerializeField] private DressSO[] dressList;
    [SerializeField] private GameObject dressListObj;
    [SerializeField] private GameObject imagePrefab;
    [SerializeField] private GameObject startImage;
    [SerializeField] private GameObject endImage;
    private int phase;
    private bool start;
    private int count = 0;
    private SocialClass[] selectClass = { SocialClass.CONTADINI , SocialClass.FARAONE, SocialClass.MERCANTI, SocialClass.SCHIAVI, SocialClass.SCRIBI, SocialClass.SOLDATI };

    private void Awake()
    {
        for (int t = 0; t < selectClass.Length; t++)
        {
            SocialClass tmp = selectClass[t];
            int r = UnityEngine.Random.Range(t, selectClass.Length);
            selectClass[t] = selectClass[r];
            selectClass[r] = tmp;
        }

        for (int t = 0; t < selectClass.Length; t++)
        {
            Debug.Log(selectClass[t]);
        }
    }
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (correctDress == numberOfPanels && phase == 1 && start)
        {
            faseTwo();
        }


    }


    public void correctDressDrop()
    {
        correctDress++;
    }

    private void faseTwo()
    {
        phase = 2;
        warDrobe.SetActive(false);
        pyramid.transform.localScale = new Vector3(4, 4, 1);
        human.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }


    private void prepareMinigame()
    {
        numberOfPanels = 0;
        phase = 1;
        correctDress = -1;
        if(human == null)
        {
            Debug.Log("entra qua");
            human = Instantiate(humanPrefab,gameObject.transform);
            //human.transform.parent = gameObject.transform;
            human.GetComponent<DragAndDropHuman>().canvas = GetComponent<Canvas>();
            human.GetComponent<RectTransform>().parent = gameObject.GetComponent<RectTransform>();
            //human.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            human.GetComponent<RectTransform>().SetSiblingIndex(2);

        }
        Debug.Log("passa di qua con "+ human);
        human.GetComponent<DragAndDropHuman>().InsertSocialClass(socialClass);
        human.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        pyramid.transform.localScale = new Vector3(1f, 1f, 1f);
        warDrobe.SetActive(true);
        AddCorrectDresses(socialClass);
        switch(socialClass)
        {
            case SocialClass.FARAONE: Description.text = descriptionText[0];
                break;
            case SocialClass.SCRIBI:
                Description.text = descriptionText[1];
                break;
            case SocialClass.SOLDATI:
                Description.text = descriptionText[2];
                break;
            case SocialClass.MERCANTI:
                Description.text = descriptionText[3];
                break;
            case SocialClass.CONTADINI:
                Description.text = descriptionText[5];
                break;
            case SocialClass.SCHIAVI:
                Description.text = descriptionText[4];
                break;

            default: break;
        }
    }

    private void AddCorrectDresses(SocialClass sc)
    {
        for (int i = 0; i < dressList.Length; i++)
        {
            if (dressList[i].socialClass == sc)
            {
                GameObject tmp = Instantiate(imagePrefab);
                tmp.transform.SetParent(dressListObj.transform);
                tmp.GetComponent<DragAndDrop>().dressSO = dressList[i];
                tmp.GetComponent<DragAndDrop>().canvas = GetComponent<Canvas>();
                numberOfPanels++;
            }
        }
        correctDress = 0;
    }

    public void correctSocialClass()
    {
        start = false;
        StartCoroutine(EndImage());

    }

    public void StartMinigame()
    {
        start = true;
        if(count % 3 == 0)
            StartCoroutine(StartImage());
        socialClass = selectClass[count];
        count++;
        prepareMinigame();
        
    }

    IEnumerator StartImage()
    {
        startImage.SetActive(true);
        yield return new WaitForSeconds(5f);
        startImage.SetActive(false);
    }

    IEnumerator EndImage()
    {
        Debug.Log("errore " + count);
        if (count % 3 != 0)
        {
            yield return new WaitForSeconds(2f);
            StartMinigame();
        }
        else
        {
            
            endImage.SetActive(true);
            yield return new WaitForSeconds(3f);
            endImage.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
