using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private int loveMeter;
    private int favoriteShirt;
    private int favoriteSteed;
    private int favoriteLance;
    private bool favoriteShirtGuessed;
    private bool favoriteSteedGuessed;
    private bool favoriteLanceGuessed;
    private string charName;
    private bool canDate;

    public NPC(string theName, int favShirt, int favSteed, int favLance)
    {
        canDate = false;
        loveMeter = 0;
        this.charName = theName;
        this.favoriteShirt = favShirt;
        this.favoriteSteed = favSteed;
        this.favoriteLance = favLance;
        favoriteShirtGuessed = false;
        favoriteSteedGuessed = false;
        favoriteLanceGuessed = false;
    }
    public void reset()
    {
        favoriteShirtGuessed = false;
        favoriteSteedGuessed = false;
        favoriteLanceGuessed = false;
        loveMeter = 0;
        canDate = false;
    }
    public string getName()
    {
        return charName;
    }
    public void shirtGuessed()
    {
        if (!favoriteShirtGuessed)
        {
            favoriteShirtGuessed = true;
            loveMeter += 1;
        }
    }
    public void steedGuessed()
    {
        if (!favoriteSteedGuessed)
        {
            favoriteSteedGuessed = true;
            loveMeter += 1;
        }
    }
    public void lanceGuessed()
    {
        if (!favoriteLanceGuessed)
        {
            favoriteLanceGuessed = true;
            loveMeter += 1;
        }
    }
    public void goodDialogue()
    {
        loveMeter += 1;
    }
    public int getLoveMeter()
    {
        return loveMeter;
    }
    void Update()
    {
        if (loveMeter > 4)
        {
            canDate = true;
        }
        else
        {
            canDate = false;
        }
    }
    public void checkChoices(int shirt, int steed, int lance)
    {
        if(shirt == favoriteShirt)
        {
            shirtGuessed();
        }
        if (steed == favoriteSteed)
        {
            steedGuessed();
        }
        if (lance == favoriteLance)
        {
            lanceGuessed();
        }
    }
}