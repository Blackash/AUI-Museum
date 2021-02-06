using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImimo : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    private Image image;
    private int j = 0;


    private void OnEnable()
    {
        j = UnityEngine.Random.Range(0, 10);
        image = GetComponent<Image>();
        StartCoroutine(MimoCourutine());
    }


    IEnumerator MimoCourutine()
    {
        for (int i = j; i < 100; i++)
        {
            image.sprite = sprites[i % 5];
            yield return new WaitForSeconds(4f);
        }


    }
}
