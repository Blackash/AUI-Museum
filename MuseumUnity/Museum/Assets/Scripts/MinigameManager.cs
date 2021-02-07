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
    [SerializeField] DialogueTrigger alreadyHaveTokenDialogue;
    public bool CanMove = true;


    public void StartMinigame(MiniGames mini, int tokenValue)
    {
        bool[] tmp = TokenManager.Instance.GetHalfTokens();
        if (mini != MiniGames.Door)
        {
            if (tmp[tokenValue - 1] == true)
            {
                alreadyHaveTokenDialogue.TriggerDialogue();
                return;
            }
        }
        CanMove = false;
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
                    doorMinigame.GetComponent<AnswerOptionManager>().StartMinigame();
                    break;
                }
        }
    }

    public void MinigameEnd()
    {
        CanMove = true;
        gameUI.SetActive(true);
    }

    public void InDialogue()
    {
        CanMove = false;
        gameUI.SetActive(false);
    }

    public void DialogueEnd()
    {
        CanMove = true;
        gameUI.SetActive(true);
    }
    public bool GetIfCanAction()
    {
        return CanMove;
    }

}
