using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool textInMotion = false; // is NPC still speaking (i.e. text is still moving as letters appear one by one)

    // Start is called before the first frame update
    void Start()
    {
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
                    lines[1] = " Thou needest no less than ten further years of training before I am within thy reach.";
                    lines[2] = "To be or not to be: that is the question…";
                    lines[3] = "--break";
                }
            } else if (lines[0].Equals("final") && mas.GetComponent<BaseScript>().setNPC().getLoveMeter() >= 3)
            {
                lines[0] = "I love you!";
                lines[1] = "It was meant to be!";
                lines[2] = "--menu";
            } else if (lines[0].Equals("final") && mas.GetComponent<BaseScript>().setNPC().getLoveMeter() < 3)
            {
                lines[0] = "I don't like you in that way...";
                lines[1] = "--menu";
            }
            DisplayText(lines[0]);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!button1.activeSelf)
            {
                textIndex++;
            }
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
                } else if(lines[textIndex] == "--menu")
                {
                    GameObject mas = GameObject.Find("MasterObject");
                    mas.GetComponent<BaseScript>().reset();
                    mas.GetComponent<BaseScript>().NextLevel(nextScene);
                }
                else
                {
                    DisplayText(lines[textIndex]);
                }
            }
            else
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

    public void DisplayText(string sentence) {
        StopAllCoroutines(); // to ensure we don't keep animating old sentence if user moves on
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        textInMotion = true;
        txt.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            txt.text += letter;
            yield return null; // wait until next frame before continuing execution
        }
        textInMotion = false;
    }

    public void GoodOptionPicked() {
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().currentNPC.goodDialogue();
        mas.GetComponent<BaseScript>().incrementNPC();
    }

    public void BadOptionPicked()
    {
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().incrementNPC();
    }
}