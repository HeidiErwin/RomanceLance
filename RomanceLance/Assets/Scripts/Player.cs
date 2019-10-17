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

    public void changeShirt(int index)
    {
            if (index == 0)
        {
            shirt.sprite = blackShirt;
        }
        if (index == 1)
        {
            shirt.sprite = whiteShirt;
        }
        if (index == 2)
        {
            shirt.sprite = redShirt;
        }
        if (index == 3)
        {
            shirt.sprite = orangeShirt;
        }
        if (index == 4)
        {
            shirt.sprite = yellowShirt;
        }
        if (index == 5)
        {
            shirt.sprite = purpleShirt;
        }

    }
}
