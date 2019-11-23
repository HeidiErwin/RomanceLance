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
    private int question;
    public bool textInMotion = false; // is NPC still speaking (i.e. text is still moving as letters appear one by one)

    // Start is called before the first frame update
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
                    lines[1] = " Thou needest no less than ten further years of training before I am within thy reach.";
                    lines[2] = "To be or not to be: that is the question…";
                    lines[3] = "--break";
                }
            }
            else if (lines[0].Equals("final") && mas.GetComponent<BaseScript>().setNPC().getLoveMeter() >= 3)
            {
                lines[0] = "I love you!";
                lines[1] = "It was meant to be!";
                lines[2] = "--menu";
            }
            else if (lines[0].Equals("final") && mas.GetComponent<BaseScript>().setNPC().getLoveMeter() < 3)
            {
                lines[0] = "I don't like you in that way...";
                lines[1] = "--menu";
            }
            else if (mas.GetComponent<BaseScript>().countNPC == 0 && lines[0].Equals("Hi… I’m Micaela. Thanks for catching me..."))
            {
                Questions(0);
                PlayerAnswers(0);
            }
            else if (mas.GetComponent<BaseScript>().countNPC == 1 && lines[0].Equals("Oooh! Fresh blood!"))
            {
                Questions(1);
                PlayerAnswers(1);
            }
            else if (mas.GetComponent<BaseScript>().countNPC == 2 && lines[0].Equals("It is time to test thy mettle, newcomer! Micaela!"))
            {
                Questions(2);
                PlayerAnswers(2);
            }
            else if (mas.GetComponent<BaseScript>().countNPC == 0 && lines[0].Equals("--joust"))
            {
                lines[0] = "NPC0 joust";
                lines[1] = "NPC0 joust 2";
                lines[2] = "--endjoust";
                mas.GetComponent<BaseScript>().JoustDialogueStart();
            }
            else if (mas.GetComponent<BaseScript>().countNPC == 1 && lines[0].Equals("--joust"))
            {
                lines[0] = "NPC1 joust";
                lines[1] = "NPC1 joust 2";
                lines[2] = "--endjoust";
                mas.GetComponent<BaseScript>().JoustDialogueStart();
            }
            else if (mas.GetComponent<BaseScript>().countNPC == 2 && lines[0].Equals("--joust"))
            {
                lines[0] = "NPC2 joust";
                lines[1] = "NPC2 joust 2";
                lines[2] = "--endjoust";
                mas.GetComponent<BaseScript>().JoustDialogueStart();
            }
            DisplayText(lines[0]);
        }
    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
         {
            if (button1.activeSelf)
            {
                Responses(true);
            } 
            else
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
                    DisplayText(lines[textIndex]);
                }
            }
            else if (lines[textIndex - 1] != "The game needs to end!" || lines[textIndex - 1] != "--endjoust")
            {
                GameObject mas = GameObject.Find("MasterObject");
                mas.GetComponent<BaseScript>().NextLevel(nextScene);
            }
            else if (lines[textIndex - 1] == "--endjoust")
            {
                GameObject mas = GameObject.Find("MasterObject");
                mas.GetComponent<BaseScript>().JoustDialogueEnd();
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

    public void Questions(int npc)
    {
        GameObject mas = GameObject.Find("MasterObject");
        PlayerAnswers(mas.GetComponent<BaseScript>().countNPC);
        if (npc == 0)
        {
            lines[3] = "NPC0 question 1";
            lines[6] = "NPC0 question 2";
            lines[9] = "NPC0 question 3";
        } else if(npc == 1)
        {
            lines[6] = "NPC1 question 1";
            lines[9] = "NPC1 question 2";
            lines[12] = "NPC1 question 3";
        } else if(npc == 2)
        {
            lines[3] = "NPC2 question 1";
            lines[6] = "NPC2 question 2";
            lines[9] = "NPC2 question 3";
        }
    }

    public void Responses(bool first)
    {
        GameObject mas = GameObject.Find("MasterObject");
        if (question == 0)
        {
            Response1(first);
            question = 1;
            PlayerAnswers(mas.GetComponent<BaseScript>().countNPC);
        } else if(question == 1)
        {
            Response2(first);
            question = 2;
            PlayerAnswers(mas.GetComponent<BaseScript>().countNPC);
        } else if(question == 2)
        {
            Response3(first);
        }
        button1.SetActive(false);
        button2.SetActive(false);
        textIndex++;
        DisplayText(lines[textIndex]);
    }

    public void Response1(bool first)
    {
        GameObject mas = GameObject.Find("MasterObject");
        if (mas.GetComponent<BaseScript>().countNPC == 0 && first)
        {
            lines[5] = "NPC0 response first 1";
            PlayerAnswers(0);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 0 && !first)
        {
            lines[5] = "NPC0 response second 1";
            PlayerAnswers(0);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 1 && first)
        {
            lines[8] = "NPC1 response first 1";
            PlayerAnswers(1);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 1 && !first)
        {
            lines[8] = "NPC1 response second 1";
            PlayerAnswers(1);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 2 && first)
        {
            lines[5] = "NPC2 response first 1";
            PlayerAnswers(2);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 2 && !first)
        {
            lines[5] = "NPC2 response second 1";
            PlayerAnswers(2);
        }
    }

    public void Response2(bool first)
    {
        GameObject mas = GameObject.Find("MasterObject");
        if (mas.GetComponent<BaseScript>().countNPC == 0 && first)
        {
            lines[8] = "NPC0 response first 2";
            PlayerAnswers(0);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 0 && !first)
        {
            lines[8] = "NPC0 response second 2";
            PlayerAnswers(0);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 1 && first)
        {
            lines[11] = "NPC1 response first 2";
            PlayerAnswers(1);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 1 && !first)
        {
            lines[11] = "NPC1 response second 2";
            PlayerAnswers(1);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 2 && first)
        {
            lines[8] = "NPC2 response first 2";
            PlayerAnswers(2);
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 2 && !first)
        {
            lines[8] = "NPC2 response second 2";
            PlayerAnswers(2);
        }
    }

    public void Response3(bool first)
    {
        GameObject mas = GameObject.Find("MasterObject");
        if (mas.GetComponent<BaseScript>().countNPC == 0 && first)
        {
            lines[11] = "NPC0 response first 3";
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 0 && !first)
        {
            lines[11] = "NPC0 response second 3";
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 1 && first)
        {
            lines[14] = "NPC1 response first 3";
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 1 && !first)
        {
            lines[14] = "NPC1 response second 3";
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 2 && first)
        {
            lines[11] = "NPC2 response first 3";
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 2 && !first)
        {
            lines[11] = "NPC2 response second 3";
        }
    }

    public void PlayerAnswers(int npc)
    {
        if(npc == 0 && question == 0)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 0 option first question 1";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 0 option second question 1";
        }
        else if(npc == 0 && question == 1)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 0 option first question 2";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 0 option second question 2";
        }
        else if (npc == 0 && question == 2)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 0 option first question 3";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 0 option second question 3";
        }
        else if (npc == 1 && question == 0)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 1 option first question 1";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 1 option second question 1";
        }
        else if (npc == 1 && question == 1)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 1 option first question 2";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 1 option second question 2";
        }
        else if (npc == 1 && question == 2)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 1 option first question 3";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 1 option second question 3";
        }
        else if (npc == 2 && question == 0)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 2 option first question 1";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 2 option second question 1";
        }
        else if (npc == 2 && question == 1)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 2 option first question 2";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 2 option second question 2";
        }
        else if (npc == 2 && question == 2)
        {
            button1.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 2 option first question 3";
            button2.GetComponent<Transform>().GetChild(0).GetComponent<Text>().text = "npc 2 option second question 3";
        }
    }
}