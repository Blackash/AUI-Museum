using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class DropPyramid : MonoBehaviour, IDropHandler
{

    [SerializeField] private SocialClass socialClass;
    [SerializeField] private GameObject human;
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
            if (other.GetComponent<DragAndDropHuman>().GetSocialClass() == socialClass)
            {
                Debug.Log("Right position");
                human.SetActive(true);
                Destroy(other);
                dressUpManager.correctSocialClass();
            }

        }
    }

}
