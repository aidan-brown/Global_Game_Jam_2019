using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStorage : MonoBehaviour
{
    [SerializeField] public int playerCurrency = 500;
    [SerializeField] public List<GameObject> towerPrefabs;
    [SerializeField] public List<GameObject> satellitePrefabs;

    public static GameStorage instance;

    void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
}
