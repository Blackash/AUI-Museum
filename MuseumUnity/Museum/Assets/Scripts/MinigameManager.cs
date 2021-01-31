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



    public void StartMinigame(MiniGames mini)
    {
        switch(mini)
        {
            case MiniGames.Riddle:
                {
                    riddleMinigame.SetActive(true);
                    riddleMinigame.GetComponent<AnswerManager>().StartMinigame();
                    break;
                }
            case MiniGames.DressUp:
                {
                    dressUpMinigame.SetActive(true);
                    dressUpMinigame.GetComponent<DressUpManager>().StartMinigame();
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
}
