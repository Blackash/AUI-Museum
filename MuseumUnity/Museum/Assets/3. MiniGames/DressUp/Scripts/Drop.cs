using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private DressType positionType;

    public void Start()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject other = eventData.pointerDrag;
            if(other.GetComponent<DragAndDrop>().GetDressType() == positionType)
            {
                Debug.Log("Right position");
            }
                //Debug.Log("Drop " + other.gameObject.name[other.gameObject.name.Length - 1]);
                //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                //gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
                //Debug.Log(int.Parse(gameObject.name.Remove(0, 3)));

                //Debug.Log("OnDrop|| other: " + (int.Parse(other.gameObject.name.Remove(0, 3))) + " this: " + (int.Parse(gameObject.name.Remove(0, 3))));
                //charInventory.switchPosition(int.Parse((other.gameObject.name.Remove(0, 3))), (int.Parse(gameObject.name.Remove(0, 3))));
            
            
        }
    }
    
}
