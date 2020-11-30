using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIInventaryHoverDisplay : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    /*public GameObject itemInfo;
    private UIItemStats itemStats;
    private Inventory inventory;
    private int i = 0;
    private bool exit = false;
    public void Start()
    {
        inventory = gameObject.GetComponentInParent<UiInventory>().charInventory;
        
    }
    /*private void Update()
    {
        if(exit)
        {
            i++;
        }
        if(i == 50)
        {
            itemStats.clearStats();
            itemInfo.SetActive(false);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        exit = false;
        i = 0;
        //Debug.Log("Pointer enter");
        itemInfo.SetActive(true);
        //Vector2 newPosition = gameObject.GetComponent<RectTransform>().position;
        //newPosition.x += -125;
        //newPosition.y += 95;
        //itemInfo.GetComponent<RectTransform>().position = newPosition;
        itemStats = itemInfo.GetComponentInChildren<UIItemStats>();
        if(!gameObject.name.Contains("Clone"))
            itemStats.ShowStats(inventory, int.Parse(gameObject.name.Remove(0, 3)));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        /// exit = true;
        //Debug.Log("Pointer exit");
        itemStats.clearStats();
        itemInfo.SetActive(false);

    }

        /*    public void enterPointer()
        {
            Debug.Log("Pointer enter");
        }
            public void exitPointer()
        {
            Debug.Log("Pointer exit");
        }
    */
}
