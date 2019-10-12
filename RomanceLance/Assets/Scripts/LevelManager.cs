using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public void QuitGame() {
        Application.Quit();
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame() {
        SceneManager.LoadScene("Dialogue");
    }

    public void Joust() {
        SceneManager.LoadScene("Joust");
    }

    public void Preparation() {
        SceneManager.LoadScene("Preparation");
    }

    public void ShowCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void ShowInstructions() {
        SceneManager.LoadScene("Instructions");
    }
}
