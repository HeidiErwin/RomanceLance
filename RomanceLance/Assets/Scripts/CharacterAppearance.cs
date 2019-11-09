using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAppearance : MonoBehaviour
{
    [SerializeField] GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        GameObject mas = GameObject.Find("MasterObject");
        npc.GetComponent<Image>().sprite = mas.GetComponent<BaseScript>().setNPC().getSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
