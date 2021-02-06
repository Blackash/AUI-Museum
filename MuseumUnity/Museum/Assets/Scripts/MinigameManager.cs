using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MiniGames { None, Riddle, DressUp, Offering, Door, Boss };

public class MinigameManager : Singleton<MinigameManager>
{
    [SerializeField] GameObject riddleMinigame;
    [SerializeField] GameObject dressUpMinigame;
    [SerializeField] GameObject OfferingMinigame;
    [SerializeField] GameObject doorMinigame;
    [SerializeField] GameObject gameUI;
    public bool inMinigame = true;


    public void StartMinigame(MiniGames mini, int tokenValue)
    {
        inMinigame = false;
        gameUI.SetActive(false);
        switch (mini)
        {
            case MiniGames.Riddle:
                {
                    riddleMinigame.SetActive(true);
                    riddleMinigame.GetComponent<AnswerManager>().StartMinigame(tokenValue);
                    break;
                }
            case MiniGames.DressUp:
                {
                    dressUpMinigame.SetActive(true);
                    dressUpMinigame.GetComponent<DressUpManager>().StartMinigame(tokenValue);
                    break;
                }
            case MiniGames.Offering:
                {
                    OfferingMinigame.SetActive(true);
                    break;
                }
            case MiniGames.Door:
                {
                    doorMinigame.SetActive(true);
                    break;
                }
        }
    }

    public void MinigameEnd()
    {
        inMinigame = true;
        gameUI.SetActive(true);
    }

    public void InDialogue()
    {
        inMinigame = false;
        gameUI.SetActive(false);
    }

    public void DialogueEnd()
    {
        inMinigame = true;
        gameUI.SetActive(true);
    }
    public bool GetIfCanAction()
    {
        return inMinigame;
    }

}
