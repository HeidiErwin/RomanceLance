using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public void QuitGame() {
        Application.Quit();
    }

    public void BackToMenu() {
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().NextLevel("Menu");
    }

    public void StartGame() {
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().NextLevel("IntroGame");
        //SceneManager.LoadScene("IntroGame");
    }

    public void SwitchScene(string nextScene)
    {
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().NextLevel(nextScene);
    }

    public void Joust() {
        SceneManager.LoadScene("Joust");
    }

    public void Preparation() {
        SceneManager.LoadScene("Preparation");
    }

    public void ShowCredits() {
        GameObject mas = GameObject.Find("MasterObject");
        mas.GetComponent<BaseScript>().NextLevel("Credits");
    }

    public void ShowInstructions() {
        SceneManager.LoadScene("Instructions");
    }

}
