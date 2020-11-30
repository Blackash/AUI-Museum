using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Scriptable objects sono script in cui generalmente non ci sono metodi, ma contengono informazioni su un dato elemento, come se fosse una parte di MODEL
public enum DressType {None, HEAD, CHEST, LEGS, JEWEL, HANDS };
public enum SocialClass {None, FARAONE, FUNZIONARI, SACERDOTI, SCRIBI, SOLDATI, ARTIGIANI, CONTADINI, SCHIAVI };

[CreateAssetMenu(fileName = "NewDress", menuName = "DressMinigame/New Dress SO", order = 1)] //permette di creare uno scriptable object (CreateAssetMenu), order server per dare una priorità tra scritable objects, il resto il menu da il nemo del SO nel menu, filename è invece il nome di base dell'oggetto
public class DressSO : ScriptableObject
{
    public string dressName = "New Dress";
    public DressType dressType = DressType.None; //defoult value
    public SocialClass socialClass = SocialClass.None; //defoult value

    //public Material itemMaterial = null; //materiale?
    public Sprite dressImage = null;
}
