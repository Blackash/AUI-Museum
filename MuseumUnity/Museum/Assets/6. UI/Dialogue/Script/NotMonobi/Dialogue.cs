using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{

    public string name; //name of the char that say something
    [TextArea(3, 10)]
    public string[] sentences;
    public float[] time;
}
