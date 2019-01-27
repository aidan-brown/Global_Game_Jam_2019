using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldText;
    public GameObject tPanel, sPanel;


    public void Update()
    {
        goldText.text = "" + GameStorage.instance.playerCurrency;
    }

    public void ToggleTPanel()
    {
        if(sPanel.activeSelf)
            sPanel.SetActive(false);
        tPanel.SetActive(!tPanel.activeSelf);
    }

    public void ToggleSPanel()
    {
        if(tPanel.activeSelf)
            tPanel.SetActive(false);
        sPanel.SetActive(!sPanel.activeSelf);
    }
}
