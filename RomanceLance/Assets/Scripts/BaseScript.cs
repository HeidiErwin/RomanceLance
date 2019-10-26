﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScript : MonoBehaviour
{
    public static string currentLevel;
    public static Sprite currentShirt;
    public static Sprite currentSteed;
    public static Sprite currentLance;
    public int shirtNumber;
    public int steedNumber;
    public int lanceNumber;
    public NPC della;
    public NPC person2;
    public NPC cyrille;
    public int currentNPC;

    private void Start()
    {
        currentNPC = 0;
        shirtNumber = 0;
        steedNumber = 0;
        lanceNumber = 0;
        della = new NPC("Della", 0, 0, 0);
        person2 = new NPC("person2", 1, 1, 1);
        cyrille = new NPC("Cyrille", 2, 2, 2);
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        currentLevel = "Menu";
    }
    public NPC getNPC()
    {
        if(currentNPC == 0)
        {
            return della;
        }
        if(currentNPC == 1)
        {
            return person2;
        }
        if(currentNPC == 2)
        {
            return cyrille;
        }
        return della;
    }
    public void incrementNPC()
    {
        if (currentNPC < 3)
        {
            currentNPC++;
        }
        else
        {
            currentNPC = 0;
        }
    }
    public void NextLevel(string nextLevel)
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Additive);
        currentLevel = nextLevel;
    }
    public void setShirt(Sprite myShirt, int numShirt)
    {
        currentShirt = myShirt;
        shirtNumber = numShirt;
    }
    public void setSteed(Sprite mySteed, int numSteed)
    {
        currentSteed = mySteed;
        steedNumber = numSteed;
    }
    public void setLance(Sprite myLance, int numLance)
    {
        currentLance = myLance;
    }
}
