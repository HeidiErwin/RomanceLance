﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Image shirt;
    [SerializeField] Sprite dogShirt;
    [SerializeField] Sprite hotDogShirt;
    [SerializeField] Sprite purpleShirt;
    [SerializeField] Sprite waifuShirt;
    [SerializeField] Sprite shakespearShirt;
    [SerializeField] Sprite squidwardShirt;
    [SerializeField] Sprite joustDogShirt;
    [SerializeField] Sprite joustHotDogShirt;
    [SerializeField] Sprite joustPurpleShirt;
    [SerializeField] Sprite joustWaifuShirt;
    [SerializeField] Sprite joustShakespearShirt;
    [SerializeField] Sprite joustSquidwardShirt;
    [SerializeField] Image steed;
    [SerializeField] Sprite horse;
    [SerializeField] Sprite roomba;
    [SerializeField] Sprite skates;
    [SerializeField] Sprite skateboard;
    [SerializeField] Sprite chair;
    [SerializeField] Sprite unicycle;
    [SerializeField] Sprite joustHorse;
    [SerializeField] Sprite joustRoomba;
    [SerializeField] Sprite joustSkates;
    [SerializeField] Sprite joustSkateboard;
    [SerializeField] Sprite joustChair;
    [SerializeField] Sprite joustUnicycle;
    [SerializeField] Image lance;
    [SerializeField] Sprite lance1;
    [SerializeField] Sprite lance2;
    [SerializeField] Sprite lance3;
    [SerializeField] Sprite lance4;
    [SerializeField] Sprite lance5;
    [SerializeField] Sprite lance6;
    public Sprite currentShirt;
    public Sprite currentLance;
    public Sprite currentSteed;
    private AudioSource source;
    [SerializeField] public AudioClip bouquetClickSound;
   
    
    public void changeShirt(int index)
    {
        if (index == 0)
        {
            shirt.sprite = dogShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 0);
            mas.GetComponent<BaseScript>().setJoustShirt(joustDogShirt);
            currentShirt = shirt.sprite;

        }
        if (index == 1)
        {
            shirt.sprite = hotDogShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 1);
            mas.GetComponent<BaseScript>().setJoustShirt(joustHotDogShirt);
            currentShirt = shirt.sprite;

        }
        if (index == 2)
        {
            shirt.sprite = purpleShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 2);
            mas.GetComponent<BaseScript>().setJoustShirt(joustPurpleShirt);
            currentShirt = shirt.sprite;
        }
        if (index == 3)
        {
            shirt.sprite = waifuShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 3);
            mas.GetComponent<BaseScript>().setJoustShirt(joustWaifuShirt);
            currentShirt = shirt.sprite;
        }
        if (index == 4)
        {
            shirt.sprite = shakespearShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 4);
            mas.GetComponent<BaseScript>().setJoustShirt(joustShakespearShirt);
            currentShirt = shirt.sprite;
        }
        if (index == 5)
        {
            shirt.sprite = squidwardShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 5);
            mas.GetComponent<BaseScript>().setJoustShirt(joustSquidwardShirt);
            currentShirt = shirt.sprite;
        }

    }
    public void changeLance(int index)
    {
        if (index == 0)
        {
            lance.sprite = lance1;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setLance(lance.sprite, 0);
            currentLance = lance.sprite;
        }
        if (index == 1)
        {
            lance.sprite = lance2;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setLance(lance.sprite, 1);
            currentLance = lance.sprite;
        }
        if (index == 2)
        {
            lance.sprite = lance3;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setLance(lance.sprite, 2);
            currentLance = lance.sprite;
        }
        if (index == 3)
        {
            lance.sprite = lance4;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setLance(lance.sprite, 3);
            currentLance = lance.sprite;
        }
        if (index == 4)
        {
            lance.sprite = lance5;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setLance(lance.sprite, 4);
            currentLance = lance.sprite;
        }
        if (index == 5)
        {
            lance.sprite = lance6;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setLance(lance.sprite, 5);
            currentLance = lance.sprite;
        }
    }
    public void changeSteed(int index)
    {
        if(index == 0){
            steed.sprite = horse;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 0);
            mas.GetComponent<BaseScript>().SetJoustSteed(joustHorse);
            currentSteed = steed.sprite;
        }
        if (index == 1)
        {
            Vector3 position = steed.rectTransform.position;
            position = position + 5 * Vector3.up;
            steed.sprite = roomba;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 1);
            mas.GetComponent<BaseScript>().SetJoustSteed(joustRoomba);
            currentSteed = steed.sprite;
            steed.rectTransform.position = position;
        }
        if (index == 2)
        {
            steed.sprite = skates;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 2);
            mas.GetComponent<BaseScript>().SetJoustSteed(joustSkates);
            currentSteed = steed.sprite;
        }
        if (index == 3)
        {
            steed.sprite = skateboard;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 3);
            mas.GetComponent<BaseScript>().SetJoustSteed(joustSkateboard);
            currentSteed = steed.sprite;
        }
        if (index == 4)
        {
            steed.sprite = chair;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 4);
            mas.GetComponent<BaseScript>().SetJoustSteed(joustChair);
            currentSteed = steed.sprite;
        }
        if (index == 5)
        {
            steed.sprite = unicycle;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 5);
            mas.GetComponent<BaseScript>().SetJoustSteed(joustUnicycle);
            currentSteed = steed.sprite;
        }
    }
}