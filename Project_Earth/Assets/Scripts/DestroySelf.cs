using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
	private GameObject earth;
    void Start()
    {
		earth = GameObject.FindGameObjectWithTag("Earth");
    }

    // Update is called once per frame
    void Update()
    {
		if(earth == null)
		{
			Destroy(gameObject);
		}
    }
}
