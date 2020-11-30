using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIItemStats : MonoBehaviour
{
    /*public GameObject itemInfo;
    public GameObject singleStat;
    private List<GameObject> listObjStats = new List<GameObject>();
    int positionY;
    //n è la posizione nell'inventario dell'oggetto
    public void ShowStats(Inventory charInventaty, int n)
    {
        positionY = 0;
        
        ItemPickUp itemToShow = charInventaty.getItemInfoFromInventary(n);
        
        if (itemToShow == null)
        {
            itemInfo.SetActive(false);
            return;
        }
        List<nameValue> listStats = itemToShow.createNameValueList();
        
        //Debug.Log(listStats);
        foreach (nameValue nv in listStats)
        {
            if (nv.value != 0)
            {
                
                listObjStats.Add(singleStatFactory(nv.name, nv.value));
            }
        }
        
    }

    private GameObject singleStatFactory(string name, int value)
    {
        GameObject newStat = GameObject.Instantiate(singleStat, gameObject.GetComponent<RectTransform>().position, Quaternion.identity) as GameObject;
        newStat.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>());
        newStat.GetComponentInChildren<TextMeshProUGUI>().text = name + ": " + value;
        //newStat.GetComponent<RectTransform>().position.Set(0f,-3f, 0f);anchoredPosition 
        newStat.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, positionY, 0);
        newStat.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
        newStat.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        positionY += -25;

        return newStat;
    }

    public void clearStats()
    {
        foreach(GameObject obj in listObjStats)
        {
            Destroy(obj);
        }
    }



    */
    
}
