using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAppearance : MonoBehaviour
{
    [SerializeField] GameObject npc;
    [SerializeField] GameObject evanBlush;
    [SerializeField] GameObject evanSad;
    [SerializeField] GameObject dellaBlush;
    [SerializeField] GameObject dellaSad;
    [SerializeField] GameObject morganBlush;
    [SerializeField] GameObject morganSad;

    void Start()
    {
        GameObject mas = GameObject.Find("MasterObject");
        BaseScript bs= mas.GetComponent<BaseScript>();
        //NPC npcScript = bs.currentNPC.GetComponent<NPC>();
        if (bs.countNPC == 0 && bs.CharA.CanDate()) { //Evan accepts
            evanBlush.SetActive(true);
        } 
        else if (bs.countNPC == 0 && !bs.CharA.CanDate()) { //Evan rejects
            evanSad.SetActive(true);
        } 
        else if (bs.countNPC == 1 && bs.CharB.CanDate()) { //Della accepts
            dellaBlush.SetActive(true);
        } 
        else if (bs.countNPC == 1 && !bs.CharB.CanDate()) { //Della rejects
            dellaSad.SetActive(true);
        } 
        else if (bs.countNPC == 2 && bs.CharC.CanDate()) { //Morgan accepts
            morganBlush.SetActive(true);
        } 
        else if (bs.countNPC == 2 && !bs.CharC.CanDate()) { //Morgan rejects
            morganSad.SetActive(true);
        }
    }
}
