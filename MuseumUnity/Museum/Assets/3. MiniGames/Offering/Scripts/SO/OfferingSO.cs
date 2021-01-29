using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Scriptable objects sono script in cui generalmente non ci sono metodi, ma contengono informazioni su un dato elemento, come se fosse una parte di MODEL




[CreateAssetMenu(fileName = "NewOffering", menuName = "OfferingMinigame/New Offering SO", order = 1)] //permette di creare uno scriptable object (CreateAssetMenu), order server per dare una priorità tra scritable objects, il resto il menu da il nemo del SO nel menu, filename è invece il nome di base dell'oggetto
public class OfferingSO : ScriptableObject
{
    public bool[] gods = { false,false,false}; //Sekhmet , Seth, Taurus
    public string offeringName = "New Offering";

    public Sprite offeringImage = null;
}
