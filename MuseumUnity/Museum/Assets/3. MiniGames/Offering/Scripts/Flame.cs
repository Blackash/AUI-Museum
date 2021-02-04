using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField] private Animator animator;


    public void turnRed()
    {
        animator.SetBool("Red", true);
        StartCoroutine(FlameCourutine());
    }

    public void turnGreen()
    {
        animator.SetBool("Red", false);
        StartCoroutine(FlameCourutine());
    }

    IEnumerator FlameCourutine()
    {
        
            yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);


    }

}
