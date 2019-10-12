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

    private float runTime = 2.5f; // how long it takes the characters to run across the screen

    public bool charactersMoving = false;

    private void Start() {
         StartJoust();
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

    private void RunSecondHalf() {
        StartCoroutine(MoveToPosition(npc.transform, new Vector3(-8, .5f, 0), runTime));
        StartCoroutine(MoveToPosition(player.transform, new Vector3(8, -.5f, 0), runTime));
    }

    IEnumerator WaitThenRunSecondHalf() {
        yield return new WaitForSeconds(2.5f);
        ShowIntenseEyes();
        yield return new WaitForSeconds(1f);
        HideIntenseEyes();
        RunSecondHalf();
    }

    public void ShowIntenseEyes() {
        intenseEyes.gameObject.SetActive(true);
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