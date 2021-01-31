using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject mimoM;
    [SerializeField] private GameObject selectorM;
    [SerializeField] private GameObject navigatorM;
    [SerializeField] private GameObject bagM;

    private List<Transform> transformM = new List<Transform>();
    void Start()
    {
        
        if (mimoM != null)
            transformM.Add(mimoM.transform);
        if (selectorM != null)
            transformM.Add(selectorM.transform);
        if (navigatorM != null)
            transformM.Add(navigatorM.transform);
        if (bagM != null)
            transformM.Add(bagM.transform);
        StartCoroutine(PositionRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private bool CheckIfInPosition()
    {
        bool tmp = true;
        foreach(Transform t in transformM)
        {
            tmp = tmp && inRightPosition(t);
        }
        return tmp;
    }

    private bool inRightPosition(Transform t)
    {
        if (t.localPosition.x < 5 && t.localPosition.x > -5)
            return true;
        return false;
    }

    IEnumerator PositionRoutine()
    {
        
            while(true)
            {
            yield return new WaitForSeconds(1f);
            if (!CheckIfInPosition())
            {
                //Debug.Log("mettersi in posizione");
            }
        }
            
        


    }
}
