using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagChildManager : MonoBehaviour
{
    [SerializeField] GameObject bagGamePrefab;
    [SerializeField] GameObject bagChieldFloor;
    private List<Transform> bags = new List<Transform>();
    private bool singleJump;
    private Transform _transform;
    private void Start()
    {
        singleJump = true;
        _transform = gameObject.transform;
    }

    private void Update()
    {
        if(!MinigameManager.Instance.GetIfCanAction())
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.B))
            StartCoroutine(BagCoroutine());
        if (_transform.localPosition.y > 4.5f && singleJump)
            CheckBag();
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
        bags.Add(bagGame.transform);
    }

    private void CheckBag()
    {
        singleJump = false;
        foreach(Transform b in bags)
        {
            float z = b.position.z;
            float x = b.position.x;

            if(Mathf.Abs(z-(_transform.position.z -0.05f)) < 1.5f && Mathf.Abs(x - (_transform.position.x + 0.85f)) < 1.5f) //0.05f e 0.085 sono gli offset
            {
                bags.Remove(b);
                Destroy(b.gameObject);
                singleJump = true;
                return;
            }
        }
        singleJump = true;
    }

}
