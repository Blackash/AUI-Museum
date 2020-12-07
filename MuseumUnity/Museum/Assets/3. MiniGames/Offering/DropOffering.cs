using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class DropOffering : MonoBehaviour, IDropHandler
{

    [SerializeField] private int totalOfferings;
    [SerializeField] private God god;
    private int currentOfferings;
    private DressUpManager dressUpManager;
    public void Start()
    {
        currentOfferings = 0;
        dressUpManager = FindObjectOfType<DressUpManager>();
    }

    public void Update()
    {
        if(currentOfferings == totalOfferings)
        {
            //game end
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject other = eventData.pointerDrag;
            if (other.GetComponent<DragAndDropOffering>().GetGodOffering() == god)
            {
                Debug.Log("Right offering");
                dressUpManager.correctSocialClass();
                currentOfferings++;
            }
            else
            {
                Debug.Log("Bad Offering");
            }
            other.SetActive(false);

        }
    }

}
