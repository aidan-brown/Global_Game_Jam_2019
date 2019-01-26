using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    //This is the public variable for Rigidibody2D and can be
    //accessed anywhere.
    public Rigidbody2D rb;

    /// <summary>
    /// Current health of the given tower that exists
    /// </summary>
    public float health;

    /// <summary>
    /// Determines the rate at which the tower fires
    /// </summary>
    public float fireRate;

    /// <summary>
    /// The amount of damage that is done by each tower, ie the bullet damage
    /// </summary>
    public double damage;

    /// <summary>
    /// Parent will be determined by the position at which it is placed
    /// </summary>
    ///private Tile parent; 

    /// <summary>
    /// The starting position relative to the placement in the world
    /// </summary>
    private int position;

    /// <summary>
    /// Can go from level 1 to 3, starts at 1
    /// </summary>
    private int level;

    /// <summary>
    /// Collider for the actual tower itself
    /// </summary>
    private BoxCollider2D collider;

    /// <summary>
    /// Base constructor that takes only the position and the tile that it is being placed on
    /// </summary>
    /// <param name="position">The tile original position</param>
    public Tower(int position /*, Tile parent*/)
    {
        level = 1;
        this.position = position;
        //this.parent = parent;
        collider = new BoxCollider2D();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "rb")
        {
            //Add health decrease here
        }
    }

}
