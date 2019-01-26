/// <summary>
/// Laser Script.
/// @author(Kobie Arndt)
/// @version(1/26/19)
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Laser : Tower 
{
    public bool enemyEnter;
    public Transform shootPos;
    public Collider collide;
    public GameObject laserPrefab;
    public GameObject laserBeam;
    public float timeSinceLastFire = 3.0f;
    private float timer = 0.0f;
    private bool isFiring = false;
    private float firingTime = 0;
    public GameObject laserFab;


    public Laser(int position /*, Tile parent, Vector3 startPos*/)
        : base(position /*, Tile parent, Vector3 startPos*/)
    {
        collide = new Collider(); //Sets a new collider
    }

    private void Start()
    {
        timeSinceLastFire = 0; //Sets the time since last fired to 0
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The object has entered the area");
        if (other.gameObject.tag == "enemy")
        {
            enemyEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            enemyEnter = false;
        }
    }

    private void Update()
    {

        if (timeSinceLastFire >= 2 && !isFiring && enemyEnter == true)
        {
            isFiring = true;
            timeSinceLastFire = 0;
        }
        else if (!isFiring)
        {
            Debug.Log(timeSinceLastFire);
            timeSinceLastFire += Time.deltaTime;
        }
        if (firingTime < 2 && isFiring)
        {
            laserFab.SetActive(true);
            firingTime += Time.deltaTime;

        }
        else if (isFiring)
        {
            Debug.Log(firingTime);
            firingTime = 0;
            isFiring = false;
            laserFab.SetActive(false);
        }
    }
   
}

