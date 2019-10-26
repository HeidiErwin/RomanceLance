using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    public AudioClip otherClip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playSound());
    }

    IEnumerator playSound() {
        AudioSource audio = GetComponent<AudioSource>();
        AudioClip StartClip = audio.clip;
        audio.Play();
        yield return new WaitForSeconds(StartClip.length);
        audio.clip = otherClip;
        audio.Play();
        audio.loop = true;
    }
}
