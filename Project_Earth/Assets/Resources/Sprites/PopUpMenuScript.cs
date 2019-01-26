using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUpMenuScript : MonoBehaviour
{
    public GameObject popUpMenu, canvas;
    private GameObject menu;
    private Camera cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            menu = Instantiate(popUpMenu, canvas.transform);
            menu.transform.position = cam.WorldToScreenPoint(transform.position);
        }
    }
}
