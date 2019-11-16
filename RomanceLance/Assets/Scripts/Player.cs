using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Image shirt;
    [SerializeField] Sprite blackShirt;
    [SerializeField] Sprite whiteShirt;
    [SerializeField] Sprite redShirt;
    [SerializeField] Sprite orangeShirt;
    [SerializeField] Sprite yellowShirt;
    [SerializeField] Sprite purpleShirt;
    [SerializeField] Image steed;
    [SerializeField] Sprite horse;
    [SerializeField] Sprite razor;
    [SerializeField] Sprite skateboard;
    [SerializeField] Sprite limescooter;
    [SerializeField] Sprite crocs;
    [SerializeField] Sprite pattyMobile;
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
            shirt.sprite = blackShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 0);
            currentShirt = shirt.sprite;

        }
        if (index == 1)
        {
            shirt.sprite = whiteShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 1);
            currentShirt = shirt.sprite;

        }
        if (index == 2)
        {
            shirt.sprite = redShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 2);
            currentShirt = shirt.sprite;
        }
        if (index == 3)
        {
            shirt.sprite = orangeShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 3);
            currentShirt = shirt.sprite;
        }
        if (index == 4)
        {
            shirt.sprite = yellowShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 4);
            currentShirt = shirt.sprite;
        }
        if (index == 5)
        {
            shirt.sprite = purpleShirt;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setShirt(shirt.sprite, 5);
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
            currentSteed = steed.sprite;
        }
        if (index == 1)
        {
            Vector3 position = steed.rectTransform.position;
            position = position + 5 * Vector3.up;
            steed.sprite = razor;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 1);
            currentSteed = steed.sprite;
            steed.rectTransform.position = position;
        }
        if (index == 2)
        {
            steed.sprite = skateboard;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 2);
            currentSteed = steed.sprite;
        }
        if (index == 3)
        {
            steed.sprite = crocs;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 3);
            currentSteed = steed.sprite;
        }
        if (index == 4)
        {
            steed.sprite = limescooter;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 4);
            currentSteed = steed.sprite;
        }
        if (index == 5)
        {
            steed.sprite = pattyMobile;
            GameObject mas = GameObject.Find("MasterObject");
            mas.GetComponent<BaseScript>().setSteed(steed.sprite, 5);
            currentSteed = steed.sprite;
        }
    }
}
