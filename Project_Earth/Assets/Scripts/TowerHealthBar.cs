using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthBar : MonoBehaviour
{
    public GameObject tower;
    public float maxHP, value;

    void Start()
    {
        transform.localScale = tower.transform.localScale;

    }

    void Update()
    {
        if(value > 0)
            value--;
        transform.localScale = new Vector3(1, (1 - (value / maxHP)) * tower.transform.localScale.y, 1);
    }
}
