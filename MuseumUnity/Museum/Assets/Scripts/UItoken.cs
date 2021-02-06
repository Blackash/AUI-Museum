using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItoken : MonoBehaviour
{
    [SerializeField] GameObject[] tokenObj;

    public void UpdateUI(int n)
    {
        tokenObj[n].SetActive(true);
    }
    
}
