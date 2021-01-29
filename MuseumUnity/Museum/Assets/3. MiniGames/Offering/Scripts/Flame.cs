using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void turnRed()
    {
        animator.SetBool("Red", true);
        StartCoroutine(FlameCourutine());
    }

    public void turnGreen()
    {
        animator.SetBool("Red", false);
    }

    IEnumerator FlameCourutine()
    {
        
            yield return new WaitForSeconds(4f);
            turnRed();


    }

}
