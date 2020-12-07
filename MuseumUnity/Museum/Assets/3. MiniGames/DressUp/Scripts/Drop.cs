﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private DressType positionType;
    private DressUpManager dressUpManager;
    public void Start()
    {
        dressUpManager = FindObjectOfType<DressUpManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject other = eventData.pointerDrag;
            if(other.GetComponent<DragAndDrop>().GetDressType() == positionType)
            {
                Debug.Log("Right position");
                gameObject.GetComponent<Image>().sprite = other.GetComponent<Image>().sprite;
                other.SetActive(false);
                dressUpManager.correctDressDrop();
            }
        }
    }
    
}
