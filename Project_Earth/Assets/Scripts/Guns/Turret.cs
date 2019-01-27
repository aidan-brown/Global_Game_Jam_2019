using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    /// <summary>
    /// Current health of the given tower that exists
    /// </summary>
    public int health = 100;

    /// <summary>
    /// Determines the rate at which the tower fires
    /// </summary>
    public float fireRate = 2;

    /// <summary>
    /// The amount of damage that is done by each tower, ie the bullet damage
    /// </summary>
    public int damage = 40;

    /// <summary>
    /// The cost of the 
    /// </summary>
    public int cost = 100;

    /// <summary>
    /// Can go from level 1 to 3, starts at 1
    /// </summary>
    private int level;

    private void Start()
    {
        level = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerBullets")
        {
            //Add health decrease here
        }
    }

}
