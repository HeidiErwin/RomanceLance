﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text txt;
    //Make sure that this dialogue GameObject has a TextLibrary script attached.
    public GameObject dialogue;
    int textIndex = 0;
    string[] lines;

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
            txt.text = lines[textIndex];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
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

                }
                else
                {
                    txt.text = lines[textIndex];
                }
            }
        }
    }
}