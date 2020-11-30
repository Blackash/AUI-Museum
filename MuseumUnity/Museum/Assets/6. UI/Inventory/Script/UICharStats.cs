using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICharStats : MonoBehaviour
{
    /*// Start is called before the first frame update
    public TextMeshProUGUI level;
    public TextMeshProUGUI wealth;
    public TextMeshProUGUI stats;
    public HeroStatsController statsController;
    private void OnEnable()
    {
        stats.text = "";
        List<nameValue> nameValueList = statsController.characterDefinition.getNameValueList();
        //Debug.Log(nameValueList[0].name);
        foreach(nameValue nv in nameValueList)
        {
            if(nv.name.Equals("Level"))
            {
                level.text = nv.value.ToString();
            }
            else { 
                if (nv.name.Equals("Wealth"))
                {
                wealth.text = nv.value.ToString();
                }else {
                        if (nv.name.Equals("SynergyAmount"))
                        {
                        //quando avremo una UI completa
                        }else{
                               stats.text = stats.text + nv.name + ": " + nv.value + "\n";
                            }
                       }   
                }   
        }
    }

    public void Update()
    {
        stats.text = "";
        List<nameValue> nameValueList = statsController.characterDefinition.getNameValueList();
        //Debug.Log(nameValueList[0].name);
        foreach (nameValue nv in nameValueList)
        {
            if (nv.name.Equals("Level"))
            {
                level.text = nv.value.ToString();
            }
            else
            {
                if (nv.name.Equals("Wealth"))
                {
                    wealth.text = nv.value.ToString();
                }
                else
                {
                    if (nv.name.Equals("SynergyAmount"))
                    {
                        //quando avremo una UI completa
                    }
                    else
                    {
                        stats.text = stats.text + nv.name + ": " + nv.value + "\n";
                    }
                }
            }
        }
    }*/
}
