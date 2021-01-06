using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private DressType positionType;
    [SerializeField] private GameObject referenceImage;
    private DressUpManager dressUpManager;
    private DragAndDropHuman human;
    public void Start()
    {
        dressUpManager = FindObjectOfType<DressUpManager>();
        human = FindObjectOfType<DragAndDropHuman>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject other = eventData.pointerDrag;
            if(other.GetComponent<DragAndDrop>().GetDressType() == positionType && other.GetComponent<DragAndDrop>().getDressSO().socialClass == human.GetSocialClass())
            {
                Debug.Log("Right position");
                //gameObject.GetComponent<Image>().sprite = other.GetComponent<Image>().sprite;
                if (other.GetComponent<DragAndDrop>().getDressSO().IsBodyTo)
                    human.NewBody(other.GetComponent<DragAndDrop>().getDressSO().dressImageHuman);
                else
                {
                    referenceImage.GetComponent<Image>().sprite = other.GetComponent<DragAndDrop>().getDressSO().dressImageHuman;
                    referenceImage.SetActive(true);
                }
                other.SetActive(false);
                dressUpManager.correctDressDrop();
            }
        }
    }
    
}
