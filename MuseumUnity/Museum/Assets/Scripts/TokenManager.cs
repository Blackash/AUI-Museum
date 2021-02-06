using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TokenManager : Singleton<TokenManager>
{
    [SerializeField] UItoken tokenUI;
    private int countToken = 0;
    private bool[] halfTokens = { false, false };

    public void NewTokenHalf(int n)
    {

        tokenUI.UpdateUI(n);
        countToken++;
        halfTokens[n-1] = true;
    }


    public bool[] GetHalfTokens()
    {
        return halfTokens;
    }

}
