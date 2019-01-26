using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenPopUpMenu : MonoBehaviour
{
    public GameObject popUpMenu;
    private GameObject menu, canvas;
    private Camera cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && menu == null)
        {
            menu = Instantiate(popUpMenu, canvas.transform);
            menu.transform.position = cam.WorldToScreenPoint(transform.position);
            menu.GetComponent<PopUpController>().tower = this.gameObject;
        }
    }
}
