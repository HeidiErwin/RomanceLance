﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAudioChooser : MonoBehaviour
{
    public AudioClip charARej;
    public AudioClip charBRej;
    public AudioClip charCRej;
    public AudioClip charAAcc;
    public AudioClip charBAcc;
    public AudioClip charCAcc;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playSound());
    }

    IEnumerator playSound()
    {
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().setNPC();
        AudioSource audio = GetComponent<AudioSource>();
        AudioClip StartClip = audio.clip;
        if (mas.GetComponent<BaseScript>().countNPC == 0 && mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() >= 3)
        {
            audio.clip = charAAcc;
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 0 && mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() < 3)
        {
            audio.clip = charARej;
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 1 && mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() >= 3)
        {
            audio.clip = charBAcc;
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 1 && mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() < 3)
        {
            audio.clip = charBRej;
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 2 && mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() >= 3)
        {
            audio.clip = charCAcc;
        }
        else if (mas.GetComponent<BaseScript>().countNPC == 2 && mas.GetComponent<BaseScript>().currentNPC.getLoveMeter() < 3)
        {
            audio.clip = charCRej;
        }
        yield return new WaitForSeconds(0);
        audio.Play();
    }
}
