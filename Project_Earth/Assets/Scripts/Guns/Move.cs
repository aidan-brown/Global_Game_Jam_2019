/// <summary>
/// Movement script for testing objects entering trigger area.
/// @author(Kobie Arndt)
/// @ version(1/26/19)
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    int maxVal = 3;
    int minVal = -3;
    float currentVal = 0;
    int direction = 1;

    void Update()
    {
        currentVal += Time.deltaTime * direction;

        if(currentVal >= maxVal)
        {
            direction *= -1;
            currentVal = maxVal;
        }
        else if(currentVal <= minVal){
            direction *= -1;
            currentVal = minVal;
        }
        transform.position = new Vector3(currentVal, 2, 0);

    }
}
