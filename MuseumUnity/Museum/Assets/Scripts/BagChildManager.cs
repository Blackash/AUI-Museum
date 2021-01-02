using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagChildManager : MonoBehaviour
{
    [SerializeField] GameObject bagGamePrefab;
    [SerializeField] GameObject bagChieldFloor;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            StartCoroutine(BagCoroutine());
    }


    IEnumerator BagCoroutine()
    {
            for(int i=0; i<5; i++)
        {
            SpawnBug();
            yield return new WaitForSeconds(4f);
        }
            
        
    }

    private void SpawnBug()
    {
        float x = Random.Range(-2.8f, 2.8f);
        float z = Random.Range(-3.2f, 3.2f);

        GameObject bagGame = Instantiate(bagGamePrefab);
     
        bagGame.transform.SetParent(bagChieldFloor.transform);

        //bagGame.transform.position = bagChieldFloor.transform.position+ new Vector3(x, 0.1f, z);
        bagGame.transform.localPosition = new Vector3(x, 0.1f, z);

    }

}
