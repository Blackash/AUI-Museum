using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOffering : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] DragAndDropOffering[] offeringList;
    void Start()
    {
        for(int i=0; i< offeringList.Length; i++)
        {
            offeringList[i].canvas = GetComponentInParent<Canvas>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
