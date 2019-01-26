using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{

    public GameObject HeldItem;

    public static ItemHolder instance;

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    void emptyHeldItem()
    {
        HeldItem = null;

    }

}
