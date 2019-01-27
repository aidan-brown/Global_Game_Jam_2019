using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public int heldTower;

    public static ItemHolder instance;

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;

        instance.emptyHeldItem();
    }

    public void emptyHeldItem()
    {
        instance.heldTower = -1;

    }

    public void SelectTower(int towerID)
    {
        instance.heldTower = towerID;
    }
}
