using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    public GameObject tower;
    public Text dpsText, frText, rText, thpText;
    public Slider hpBar;

    public void Close()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        
    }
}
