using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    /// <summary>
    /// Current health of the given tower that exists
    /// </summary>
    public int health;

    /// <summary>
    /// Determines the rate at which the tower fires
    /// </summary>
    public float fireRate;

    /// <summary>
    /// The amount of damage that is done by each tower, ie the bullet damage
    /// </summary>
    public int damage;

    /// <summary>
    /// The cost of the 
    /// </summary>
    public int cost;

    /// <summary>
    /// Can go from level 1 to 3, starts at 1
    /// </summary>
    private int level;

    /// <summary>
    /// A list of all enemies in range to be shot
    /// </summary>
    public List<GameObject> enemiesInRange = new List<GameObject>();

    private void Start()
    {
        level = 1;
    }

    public void Update()
    {
        while (enemiesInRange.Count > 0 && enemiesInRange[0] == null)
        {
            enemiesInRange.RemoveAt(0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemyBullet")
        {
            health -= other.gameObject.GetComponent<ProjectileBase>().damage;
            if (health <= 0)
            {
                if (GetComponentInParent<Tile>() != null)
                    GetComponentInParent<Tile>().removeTower();
                else
                    Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The object has entered the area");
        if (other.gameObject.tag == "Enemy" && !enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
