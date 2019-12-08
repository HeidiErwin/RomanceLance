using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectAskOut : MonoBehaviour
{
    public void Start() {
        GameObject mas = GameObject.Find("MasterObject");

        Debug.Log(mas.GetComponent<BaseScript>().CharA.getLoveMeter() + " is his love meter");
        Debug.Log(mas.GetComponent<BaseScript>().CharB.getLoveMeter() + " is her love meter");
    }

    public void SelectCharacter(int num)
    {
        GameObject mas = GameObject.Find("MasterObject");
        BaseScript bs = mas.GetComponent<BaseScript>();

        if (num == 0)
        {
            bs.countNPC = 0;
            bs.currentNPC = bs.CharA;
        }
        if (num == 1)
        {
            mas.GetComponent<BaseScript>().countNPC = 1;
            bs.currentNPC = bs.CharB;
        }
        if (num == 2)
        {
            mas.GetComponent<BaseScript>().countNPC = 2;
            bs.currentNPC = bs.CharC;
        }
    }
}
