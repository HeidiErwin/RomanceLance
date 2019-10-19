using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Image shirt;
    [SerializeField] Sprite blackShirt;
    [SerializeField] Sprite whiteShirt;
    [SerializeField] Sprite redShirt;
    [SerializeField] Sprite orangeShirt;
    [SerializeField] Sprite yellowShirt;
    [SerializeField] Sprite purpleShirt;
    public Sprite currentShirt;
    public Sprite currentLance;
    public Sprite currentSteed;

    public void changeShirt(int index)
    {
        if (index == 0)
        {
            shirt.sprite = blackShirt;
            currentShirt = shirt.sprite;
        }
        if (index == 1)
        {
            shirt.sprite = whiteShirt;
            currentShirt = shirt.sprite;
        }
        if (index == 2)
        {
            shirt.sprite = redShirt;
            currentShirt = shirt.sprite;
        }
        if (index == 3)
        {
            shirt.sprite = orangeShirt;
            currentShirt = shirt.sprite;
        }
        if (index == 4)
        {
            shirt.sprite = yellowShirt;
            currentShirt = shirt.sprite;
        }
        if (index == 5)
        {
            shirt.sprite = purpleShirt;
            currentShirt = shirt.sprite;
        }

    }
    public void changeLance(int index)
    {

    }
    public void changeSteed(int index)
    {

    }
}
