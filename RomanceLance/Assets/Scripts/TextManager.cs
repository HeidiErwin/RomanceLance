﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TextManager : MonoBehaviour
{
    public Text txt;
    //Make sure that this dialogue GameObject has a TextLibrary script attached.
    public GameObject dialogue;
    public string nextScene;
    int textIndex = 0;
    string[] lines;
    public GameObject button1;
    public GameObject button2;
    private int question;
    public bool textInMotion = false; // is NPC still speaking (i.e. text is still moving as letters appear one by one)

    void Start()
    {
        question = 0;
        //"lib" now refers to TextLibrary script of "dialogue".
        TextLibrary lib = dialogue.GetComponent<TextLibrary>();
        //"lines" now refers to the textLines array from "dialogue".
        lines = lib.textLines;

        //Avoids catastrophic failure if the array is empty.
        if (lines.Length != 0)
        {
            GameObject mas = GameObject.Find("MasterObject");
            if (mas.GetComponent<BaseScript>().setNPC().hasLost() && lines[0].Equals("dialogue"))
            {
                if (mas.GetComponent<BaseScript>().countNPC == 0)
                {
                    lines[0] = "You’re, uh… pretty good…";
                }
                else if (mas.GetComponent<BaseScript>().countNPC == 1)
                {
                    lines[0] = "Rats! I thought I had you for sure! Oh well, good match!";
                }
                else
                {
                    lines[0] = "...I underestimated thee. I thought myself experienced, but it seems I’ve much to learn.";
                }
            }
            else if (!mas.GetComponent<BaseScript>().setNPC().hasLost() && lines[0].Equals("dialogue"))
            {
                if (mas.GetComponent<BaseScript>().countNPC == 0)
                {
                    lines[0] = "I… I can’t believe it! I really won!";
                }
                else if (mas.GetComponent<BaseScript>().countNPC == 1)
                {
                    lines[0] = "Hehehe! Nice try, but you can’t bring me down that easily!";
                }
                else
                {
                    lines[0] = "A predictable result.";
                    lines[1] = "Thou needest no less than ten further years of training before I am within thy reach.";
                    lines[2] = "To be or not to be: that is the question…";
                    lines[3] = "--break";
                }
            }
            else if (lines[0].Equals("final") && mas.GetComponent<BaseScript>().currentNPC.CanDate())
            {
                lines[0] = "I love you, too!";
                lines[1] = "It was meant to be!";
                lines[2] = "--menu";
            }
            else if (lines[0].Equals("final") && !mas.GetComponent<BaseScript>().currentNPC.CanDate())
            {
                lines[0] = "I don't like you in that way...";
                lines[1] = "--menu";
            }

            // WHAT THEY SAY DURING THE JOUST
            else if (mas.GetComponent<BaseScript>().countNPC == 0 && lines[0].Equals("--joust")) // this depends on outfit
            {
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 0) {
                    lines[0] = "Eeeeek!";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 1)
                {
                    lines[0] = "Woah!";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 2)
                {
                    lines[0] = "H-huh?";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 3)
                {
                    lines[0] = "P-pretty!";
                }
            }
            else if (mas.GetComponent<BaseScript>().countNPC == 1 && lines[0].Equals("--joust"))
            {
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 0)
                {
                    lines[0] = "YA UGLY";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 1)
                {
                    lines[0] = "YOU AIGHT";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 2)
                {
                    lines[0] = "YOU PURDY";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 3)
                {
                    lines[0] = "Hey there ;)))";
                }
            }
            else if (mas.GetComponent<BaseScript>().countNPC == 2 && lines[0].Equals("--joust"))
            {
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 0)
                {
                    lines[0] = "Taste the minty freshness of my steel!";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 1)
                {
                    lines[0] = "Away with thee!";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 2)
                {
                    lines[0] = "Nani?!";
                }
                if (mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() == 3)
                {
                    lines[0] = "S-so beautiful!";
                }
            }
            txt.text = lines[0];
            //DisplayText(lines[0]);
        }
    
    }

    void Update()
    {
        if (!button1.activeSelf && Input.GetKeyDown(KeyCode.Return) && SceneManager.GetSceneAt(1).name != "Joust") 
         {
               textIndex++;

            //Conditional to prevent accessing an invalid index.
            if (!(textIndex >= lines.Length))
            {
                //Enables use of an escape sequence in the library
                //  If "--choice" appears as a line in the array,
                //  this code will run rather than update the text
                //  in the dialogue box.
                if (lines[textIndex] == "--break")
                {
                    button1.SetActive(true);
                    button2.SetActive(true);
                }
                else if (lines[textIndex] == "--menu")
                {
                    GameObject mas = GameObject.Find("MasterObject");
                    mas.GetComponent<BaseScript>().reset();
                    mas.GetComponent<BaseScript>().NextLevel(nextScene);
                }
                else
                {
                    txt.text = lines[textIndex];
                    //DisplayText(lines[textIndex]);
                }
            }
            else if (SceneManager.GetSceneAt(1).name != "AskScene") //if(lines[textIndex-1] != "The game needs to end!")
             {
                GameObject mas = GameObject.Find("MasterObject");
                mas.GetComponent<BaseScript>().NextLevel(nextScene);
            }
        } 
    }

    //This is called when player chooses an option
    public void changeDialogue(GameObject newDialogue)
    {
        dialogue = newDialogue;
        textIndex = 0;
        Start();
        button1.SetActive(false);
        button2.SetActive(false);
    }

    //public void DisplayText(string sentence) {
    //    StopAllCoroutines(); // to ensure we don't keep animating old sentence if user moves on
    //    StartCoroutine(TypeSentence(sentence));
    //}

    //IEnumerator TypeSentence(string sentence) {
    //    textInMotion = true;
    //    txt.text = "";
    //    foreach (char letter in sentence.ToCharArray()) {
    //        txt.text += letter;
    //        yield return null; // wait until next frame before continuing execution
    //    }
    //    textInMotion = false;
    //}
        
    public void GoodOptionPicked() {
        GameObject mas = GameObject.Find("MasterObject");
        BaseScript bs = mas.GetComponent<BaseScript>();
        bs.currentNPC.goodDialogue();
        GameObject.Find("Character").GetComponent<Image>().sprite = GetHappySpriteFor(bs.countNPC, true);
        bs.incrementNPC();
    }

    // returns a sprite, if not happy then angry
    private Sprite GetHappySpriteFor(int countNPC, bool happy) {
        GameObject mas = GameObject.Find("MasterObject");
        BaseScript bs = mas.GetComponent<BaseScript>();
        if (happy) {
            if (countNPC == 0) {
                return bs.charAhappy;
            } else if (countNPC == 1) {
                return bs.charBhappy;
            } else {
                return bs.charChappy;
            }
        } else {
            if (countNPC == 0) {
                return bs.charAangry;
            } else if (countNPC == 1) {
                return bs.charBangry;
            } else {
                return bs.charCangry;
            }
        }
    }

    public void BadOptionPicked()
    {
        GameObject mas = GameObject.Find("MasterObject");
        BaseScript bs = mas.GetComponent<BaseScript>();
        bs.currentNPC.badDialogue();
        GameObject.Find("Character").GetComponent<Image>().sprite = GetHappySpriteFor(bs.countNPC, false);
        bs.incrementNPC();
    }
    
}