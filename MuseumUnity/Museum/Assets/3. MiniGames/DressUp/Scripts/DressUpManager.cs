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
    [SerializeField] private string[] descriptionText = new string[6];
    [SerializeField] private Text Description;
    [SerializeField] private SocialClass socialClass;
    [SerializeField] private DressSO[] dressList;
    [SerializeField] private GameObject dressListObj;
    [SerializeField] private GameObject imagePrefab;
    private int phase;
    void Start()
    {
        numberOfPanels = 0;
        phase = 1;
        correctDress = -1;
        prepareMinigame();
    }

    // Update is called once per frame
    void Update()
    {
        if (correctDress == numberOfPanels && phase == 1)
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
        human.GetComponent<DragAndDropHuman>().InsertSocialClass(socialClass);
        AddCorrectDresses(socialClass);
        switch(socialClass)
        {
            case SocialClass.FARAONE: Description.text = descriptionText[5];
                break;
            case SocialClass.SCRIBI:
                Description.text = descriptionText[4];
                break;
            case SocialClass.SOLDATI:
                Description.text = descriptionText[3];
                break;
            case SocialClass.MERCANTI:
                Description.text = descriptionText[2];
                break;
            case SocialClass.CONTADINI:
                Description.text = descriptionText[0];
                break;
            case SocialClass.SCHIAVI:
                Description.text = descriptionText[1];
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
        //endMinigame();
    }
}
