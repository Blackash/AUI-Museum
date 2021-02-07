using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject scarabPrefab;


    public void AddScore()
    {
        GameObject tmp = Instantiate(scarabPrefab);
        tmp.transform.SetParent(gameObject.transform);
    }

    public void ResetScore()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
