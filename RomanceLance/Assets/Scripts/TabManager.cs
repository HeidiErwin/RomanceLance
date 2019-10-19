using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] int shirtButton;
    [SerializeField] int lanceButton;
    [SerializeField] int steedButton;
    public static int tabSelected;

    public void shirtTabs()
    {
        for (int i = 1; i < 7; i++) {
            this.transform.GetChild(0).transform.GetChild(i).gameObject.SetActive(false);
            this.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(false);
            this.transform.GetChild(2).transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void lanceTabs()
    {
        for (int j = 1; j < 7; j++)
        {
            this.transform.GetChild(0).transform.GetChild(j).gameObject.SetActive(true);
            this.transform.GetChild(1).transform.GetChild(j).gameObject.SetActive(false);
            this.transform.GetChild(2).transform.GetChild(j).gameObject.SetActive(false);
        }
    }
    public void steedTabs()
    {
        for (int k = 1; k < 7; k++)
        {
            this.transform.GetChild(0).transform.GetChild(k).gameObject.SetActive(false);
            this.transform.GetChild(1).transform.GetChild(k).gameObject.SetActive(true);
            this.transform.GetChild(2).transform.GetChild(k).gameObject.SetActive(false);
        }
    }

}
