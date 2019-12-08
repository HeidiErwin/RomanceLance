using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joust : MonoBehaviour
{
    [SerializeField] Image intenseEyes;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject player;
    [SerializeField] GameObject npc;
    [SerializeField] Animation shingAnim;
    [SerializeField] Sprite evanEyes;
    [SerializeField] Sprite dellaEyes;
    [SerializeField] Sprite morganEyes;

    private int hearts;
    private int lance;

    private float runTime = 2.5f; // how long it takes the characters to run across the screen

    public bool charactersMoving = false;

    private void Start() {
        GameObject mas = GameObject.Find("MasterObject");
        int shirt = mas.GetComponent<BaseScript>().shirtNumber;
        int steed = mas.GetComponent<BaseScript>().steedNumber;
        lance = mas.GetComponent<BaseScript>().lanceNumber;
        npc.GetComponent<SpriteRenderer>().sprite = mas.GetComponent<BaseScript>().currentNPC.getJSprite();
        BaseScript bs = mas.GetComponent<BaseScript>();
        bs.currentNPC.checkChoices(shirt, steed, lance);
        Debug.Log("current npsee is " + bs.currentNPC.charName);
        hearts = mas.GetComponent<BaseScript>().currentNPC.getLoveMeter();
        if(bs.countNPC == 0) {
            intenseEyes.sprite = evanEyes;
        } else if (bs.countNPC == 1) {
            intenseEyes.sprite = dellaEyes;
        } else if (bs.countNPC == 2) {
            intenseEyes.sprite = morganEyes;
        }
        StartJoust();
        player.gameObject.GetComponent<SpriteRenderer>().sprite = BaseScript.currentJoustShirt;
        player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = BaseScript.currentJoustSteed;
        player.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = BaseScript.currentLance;
    }

    public void StartJoust() {
        StartCoroutine(RunFirstHalf());
    }

    IEnumerator RunFirstHalf() {
        StartCoroutine(MoveToPosition(npc.transform, new Vector3(0, -3, 0), runTime));
        StartCoroutine(MoveToPosition(player.transform, new Vector3(0, -2, 0), runTime));
        StartCoroutine(WaitThenRunSecondHalf());
        yield return null;
    }

    public void RunSecondHalf() {
        if (WhoFalls().Equals("player"))
        {
            StartCoroutine(MoveToPosition(npc.transform, new Vector3(-8, -3, 0), runTime));
            StartCoroutine(Falls(player.transform, runTime, -1));
        }
        else
        {
            StartCoroutine(MoveToPosition(player.transform, new Vector3(8, -2, 0), runTime));
            StartCoroutine(Falls(npc.transform, runTime, 1));
        }
        StartCoroutine(WaitThenChangeScene());
    }

    IEnumerator WaitThenRunSecondHalf() {
        yield return new WaitForSeconds(2.5f);
        ShowHeartsAndText();
        GameObject mas = GameObject.Find("MasterObject");
        yield return new WaitForSeconds(3f);
        HideHeartsAndText();
        RunSecondHalf();
    }

    public string WhoFalls()
    {
        if(lance == 1 || lance == 2 || lance == 3)
        {
            return "player";
        }
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().setNPC().defeat();
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
        BaseScript bs = mas.GetComponent<BaseScript>();
        string nextSceneName = "";
        if (bs.countNPC == 0) {
            nextSceneName = "CharADialog";
        } else if (bs.countNPC == 1) {
            nextSceneName = "CharBDialog";
        } else if (bs.countNPC == 2) {
            nextSceneName = "CharCDialog";
        }
        mas.GetComponent<BaseScript>().PrepReset();
        bs.NextLevel(nextSceneName);
    }

    public void ShowHeartsAndText() {
        ui.gameObject.SetActive(true);
        for(int i = 0; i<3; i++)
        {
            ui.transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 0; i<hearts; i++)
        {
            ui.transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(true);
        }
        shingAnim.Play();
    }

    public void HideHeartsAndText() {
        ui.gameObject.SetActive(false);
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