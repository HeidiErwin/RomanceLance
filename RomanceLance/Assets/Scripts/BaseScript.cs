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
    public static Sprite currentJoustShirt;
    public static Sprite currentJoustSteed;

    public Sprite defaultShirt;
    public Sprite defaultSteed;
    public Sprite defaultLance;
    public Sprite defaultJoustShirt;
    public Sprite defaultJoustSteed;
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
    public Sprite charAhappy;
    public Sprite charAangry;
    public Sprite charBsprite;
    public Sprite charBjoust;
    public Sprite charBhappy;
    public Sprite charBangry;
    public Sprite charCsprite;
    public Sprite charCjoust;
    public Sprite charChappy;
    public Sprite charCangry;

    private void Start()
    {
        countNPC = 0;
        shirtNumber = 0;
        steedNumber = 0;
        lanceNumber = 0;
        //Evan: likes dog shirt + chair (basic boi) + basic sword
        CharA = new NPC("CharA", 0, 4, 3, charAsprite, charAjoust);
        //Della: likes bowling shirt (competitive) + skateboard + excalibur
        CharB = new NPC("CharB", 2, 3, 5, charBsprite, charBjoust);
        //Morgan: likes Shookspeare shirt + miniature mike + bouquet (romantic)
        CharC = new NPC("CharC", 4, 0, 4, charCsprite, charCjoust);
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        currentLevel = "Menu";
        currentNPC = CharA;
        currentShirt = defaultShirt;
        currentSteed = defaultSteed;
        currentLance = defaultLance;
        currentJoustShirt = defaultJoustShirt;
        currentJoustSteed = defaultJoustSteed;

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
        lanceNumber = numLance;
    }
    public void setJoustShirt(Sprite myJoustShirt)
    {
        currentJoustShirt = myJoustShirt;
    }
    public void SetJoustSteed(Sprite joustSteed) 
    {
        currentJoustSteed = joustSteed;
    }
    public void PrepReset()
    {
        setShirt(defaultShirt, 0);
        setSteed(defaultSteed, 0);
        setLance(defaultLance, 0);
        setJoustShirt(defaultJoustShirt);
        SetJoustSteed(defaultJoustSteed);
    }
    public void reset()
    {
        CharA.reset();
        CharB.reset();
        CharC.reset();
        countNPC = 0;
        shirtNumber = 0;
        steedNumber = 0;
        lanceNumber = 0;
        currentNPC = CharA;
    }
}
