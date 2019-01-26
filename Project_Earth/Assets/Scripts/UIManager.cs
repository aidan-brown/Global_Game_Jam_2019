using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpBar;
    private int totalHP = 100, gold = 0;
    public Text goldText;
    public GameObject earth, tPanel, sPanel;

    public void Update()
    {
        hpBar.value = 100 - totalHP;
        goldText.text = "" + gold;
    }

    public void ToggleTPanel()
    {
        if(sPanel.active == false)
            tPanel.SetActive(!tPanel.active);
    }

    public void ToggleSPanel()
    {
        if(tPanel.active == false)
            sPanel.SetActive(!sPanel.active);
    }
}
