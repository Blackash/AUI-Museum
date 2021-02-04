using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class DropOffering : MonoBehaviour, IDropHandler
{

    [SerializeField] private int totalOfferings;
    public int god;
    [SerializeField] Flame flameAnimator;
    [SerializeField] Sprite emptyImage;
    private int currentOfferings;
    private OfferingManager offeringManager;
    public void Start()
    {
        currentOfferings = 0;
        offeringManager = FindObjectOfType<OfferingManager>();
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
        Debug.Log("drop");
        if (eventData.pointerDrag != null)
        {
            GameObject other = eventData.pointerDrag;
            GetComponent<Image>().sprite = other.GetComponent<DragAndDropOffering>().GetOffering().offeringImage;
            if (other.GetComponent<DragAndDropOffering>().GetGodOffering()[god])
            {
                Debug.Log("Right offering");
                flameAnimator.gameObject.SetActive(true);
                flameAnimator.turnGreen();
                currentOfferings++;

            }
            else
            {
                Debug.Log("Bad Offering");
                flameAnimator.gameObject.SetActive(true);
                flameAnimator.turnRed();
            }
            other.SetActive(false);
            StartCoroutine(BurnCouroutine());
        }

    }

    IEnumerator BurnCouroutine()
    {

        yield return new WaitForSeconds(3f);
        GetComponent<Image>().sprite = emptyImage;


    }
}
