using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScript : MonoBehaviour
{
    public static string currentLevel;
    public static Sprite currentShirt;
    public static Sprite currentSteed;
    public static Sprite currentLance;

    private void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        currentLevel = "Menu";
    }
    public void NextLevel(string nextLevel)
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Additive);
        currentLevel = nextLevel;
    }

    public void setShirt(Sprite myShirt)
    {
        currentShirt = myShirt;
    }
    public void setSteed(Sprite mySteed)
    {
        currentSteed = mySteed;
    }
    public void setLance(Sprite myLance)
    {
        currentLance = myLance;
    }
}
