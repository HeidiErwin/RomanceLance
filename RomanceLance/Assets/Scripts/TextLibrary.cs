using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLibrary : MonoBehaviour
{
    //This array holds all the lines of dialogue for the scene/character.
    //Each string in each position of the array is a different line of dialogue.
    //  Keep in mind that, when the player presses enter, the next item in the
    //  array will appear.
    //Since the array is public, the contents can be freely modified for each library
    //  of dialogue created. Whenever you want to add dialogue to a library,
    //  create a new empty in the scene, attach a TextLibrary script, and then,
    //  from the inspector, add as many lines of dialogue as you please to the
    //  TextLibrary script component of the GameObject.
    //To use the dialogue in the text of the scene, set the GameObject with the
    //  appropriate TextLibrary to the public "dialogue" field of the
    //  TextManager component of the scene's canvas ojbect.
    public string[] textLines = new string[3];
    private int dialogueSelected;

    // Start is called before the first frame update
    void Start()
    {
        dialogueSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}