using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressUpManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int correctDress;
    [SerializeField] private int numberOfPanels;
    [SerializeField] private GameObject pyramid;
    [SerializeField] private GameObject warDrobe;
    [SerializeField] private GameObject human;

    private int phase;
    void Start()
    {
        phase = 1;
        correctDress = 0;        
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

    public void correctSocialClass()
    {
        //endMinigame();
    }
}
