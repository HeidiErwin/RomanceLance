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
    public string charName;
    private Sprite sprite;
    private Sprite joustsprite;
    private bool isDefeated;

    public NPC(string theName, int favShirt, int favSteed, int favLance, Sprite appear,
        Sprite joustappear)
    {
        isDefeated = false;
        loveMeter = 0;
        this.charName = theName;
        this.favoriteShirt = favShirt;
        this.favoriteSteed = favSteed;
        this.favoriteLance = favLance;
        favoriteShirtGuessed = false;
        favoriteSteedGuessed = false;
        favoriteLanceGuessed = false;
        sprite = appear;
        joustsprite = joustappear;
    }
    public void reset()
    {
        favoriteShirtGuessed = false;
        favoriteSteedGuessed = false;
        favoriteLanceGuessed = false;
        loveMeter = 0;
    }
    public string getName()
    {
        return charName;
    }
    public Sprite getSprite()
    {
        return sprite;
    }
    public Sprite getJSprite()
    {
        return joustsprite;
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
    public void badDialogue() {
        //loveMeter += 1;
    }
    public bool hasLost()
    {
        return isDefeated;
    }
    public void defeat()
    {
        isDefeated = true;
    }
    public int getLoveMeter()
    {
        return loveMeter;
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

    public bool CanDate() {
        return (loveMeter >= 3);
    }
}