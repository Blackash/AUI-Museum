﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OfferingManager : MonoBehaviour
{
    [SerializeField] private GameObject offeringListPrefab;
     
    [SerializeField] private GameObject startImage;
    [SerializeField] private GameObject endImage;
    [SerializeField] private Image godObject;
    [SerializeField] private Sprite[] godSprites;
    [SerializeField] private DropOffering altar;
    [SerializeField] private int[] godNumberOfOfferings;
    [SerializeField] private GameObject floorProjection;
    // Start is called before the first frame update
    private bool start = false;
    private GameObject offeringList;
    private int countGod = 0;
    private int currentOffering;
    private void prepareMinigame()
    {
        offeringList = Instantiate(offeringListPrefab, gameObject.transform);
        //human.transform.parent = gameObject.transform;
        offeringList.GetComponent<RectTransform>().parent = gameObject.GetComponent<RectTransform>();
        //human.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        offeringList.GetComponent<RectTransform>().SetSiblingIndex(2);
        godObject.sprite = godSprites[countGod];
        altar.god = countGod;
    }

    private bool test = false;
    private void Update()
    {
        if(!test)
        {
            test = true;
            StartMinigame();
        }
    }

    public void correctOffering()
    {
        currentOffering++;
        if (currentOffering == godNumberOfOfferings[countGod])
            StartCoroutine(EndImage());
    }

    public void StartMinigame()
    {
        floorProjection.SetActive(true);
        currentOffering = 0;
        start = true;
        StartCoroutine(StartImage());
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
        if (countGod != 2)
        {
            Destroy(offeringList);
            yield return new WaitForSeconds(1f);
            countGod++;
            currentOffering = 0;
            prepareMinigame();
        }
        else
        {
            endImage.SetActive(true);
            yield return new WaitForSeconds(3f);
            endImage.SetActive(false);
            floorProjection.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
