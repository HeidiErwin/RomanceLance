using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joust : MonoBehaviour
{
    [SerializeField] Image intenseEyes;
    [SerializeField] GameObject player;
    [SerializeField] GameObject npc;
    private int hearts;
    private int lance;
    public string nextScene;

    private float runTime = 2.5f; // how long it takes the characters to run across the screen

    public bool charactersMoving = false;

    private void Start() {
         GameObject mas = GameObject.Find("MasterObject");
         int shirt = mas.GetComponent<BaseScript>().shirtNumber;
         int steed = mas.GetComponent<BaseScript>().steedNumber;
         lance = mas.GetComponent<BaseScript>().lanceNumber;
         mas.GetComponent<BaseScript>().currentNPC.checkChoices(shirt, steed, lance);
         hearts = mas.GetComponent<BaseScript>().currentNPC.getLoveMeter();
         StartJoust();
         player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = BaseScript.currentShirt;
         player.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = BaseScript.currentSteed;
    }

    public void StartJoust() {
        StartCoroutine(RunFirstHalf());
    }

    IEnumerator RunFirstHalf() {
        StartCoroutine(MoveToPosition(npc.transform, new Vector3(0, .5f, 0), runTime));
        StartCoroutine(MoveToPosition(player.transform, new Vector3(0, -.5f, 0), runTime));
        StartCoroutine(WaitThenRunSecondHalf());
        yield return null;
    }

    public void RunSecondHalf() {
        if (WhoFalls().Equals("player"))
        {
            StartCoroutine(MoveToPosition(npc.transform, new Vector3(-8, .5f, 0), runTime));
            StartCoroutine(Falls(player.transform, runTime, -1));
        }
        else
        {
            StartCoroutine(MoveToPosition(player.transform, new Vector3(8, -.5f, 0), runTime));
            StartCoroutine(Falls(npc.transform, runTime, 1));
        }
        StartCoroutine(WaitThenChangeScene());
    }

    IEnumerator WaitThenRunSecondHalf() {
        yield return new WaitForSeconds(2.5f);
        ShowIntenseEyes();
        yield return new WaitForSeconds(1f);
        HideIntenseEyes();
        RunSecondHalf();
    }

    public string WhoFalls()
    {
        if(lance == 1 || lance == 2 || lance == 3)
        {
            return "player";
        }
        return "npc";
    }

    IEnumerator Falls(Transform transform, float timeToMove, int direction)
    {
        Quaternion currentRot = transform.rotation;
        float t = 0f;
        while (t < 0.6)
        {
            t += Time.deltaTime / timeToMove;
            transform.Rotate(direction * Vector3.back);
            yield return null;
        }
    }

    IEnumerator WaitThenChangeScene()
    {
        yield return new WaitForSeconds(runTime);
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().NextLevel(
            mas.GetComponent<BaseScript>().currentNPC.getName() + "Dialog");
    }

    public void ShowIntenseEyes() {
        intenseEyes.gameObject.SetActive(true);
        for(int i = 0; i<4; i++)
        {
            intenseEyes.transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 0; i<hearts; i++)
        {
            intenseEyes.transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void HideIntenseEyes() {
        intenseEyes.gameObject.SetActive(false);
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove) {
        Vector3 currentPos = transform.position;
        float t = 0f;
        while (t < 1) {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
}