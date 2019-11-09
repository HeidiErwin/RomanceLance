using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectAskOut : MonoBehaviour
{
    public void SelectCharacter(int num)
    {
        GameObject mas = GameObject.Find("MasterObject");
        if(num == 0)
        {
            mas.GetComponent<BaseScript>().countNPC = 0;
        }
        if(num == 1)
        {
            mas.GetComponent<BaseScript>().countNPC = 1;
        }
        if(num == 2)
        {
            mas.GetComponent<BaseScript>().countNPC = 2;
        }
    }
}
