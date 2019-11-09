using System.Collections;
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
    public NPC CharA;
    public NPC CharB;
    public NPC CharC;
    public int countNPC;
    public NPC currentNPC;
    public Sprite charAsprite;
    public Sprite charAjoust;
    public Sprite charBsprite;
    public Sprite charBjoust;
    public Sprite charCsprite;
    public Sprite charCjoust;

    private void Start()
    {
        countNPC = 0;
        shirtNumber = 0;
        steedNumber = 0;
        lanceNumber = 0;
        //No name yet
        CharA = new NPC("CharA", 0, 0, 0, charAsprite, charAjoust);
        //Della
        CharB = new NPC("CharB", 1, 1, 1, charBsprite, charBjoust);
        //Cyrille
        CharC = new NPC("CharC", 2, 2, 2, charCsprite, charCjoust);
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        currentLevel = "Menu";
        currentNPC = CharA;
    }
    public NPC setNPC()
    {
        if(countNPC == 0)
        {
            return CharA;
        }
        if(countNPC == 1)
        {
            return CharB;
        }
        if(countNPC == 2)
        {
            return CharC;
        }
        else return CharA;
    }
    public void incrementNPC()
    {
        if (countNPC < 3)
        {
            countNPC++;
            currentNPC = setNPC();
        }
        else
        {
            countNPC = 0;
            currentNPC = setNPC();
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
    public void reset()
    {
        CharA.reset();
        CharB.reset();
        CharC.reset();
    }
}
