using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Image shirt;
    [SerializeField] Sprite blackShirt;
    [SerializeField] Sprite whiteShirt;

    public void changeShirt(int index)
    {
            if (index == 0)
        {
            shirt.sprite = blackShirt;
        }
        else
        {
            shirt.sprite = whiteShirt;
        }
    }
}
