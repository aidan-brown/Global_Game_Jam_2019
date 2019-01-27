using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Tower
{
    public bool enemeyEnter;
    public Transform shootPos;
    public Collider collide;
    public GameObject bulletPrefab;
    public GameObject bulletFab;
    public float timeSinceLastFire = 5.0f;
    public bool enemyEnter;
    public bool isFiring = false;
    private float firingTime = 0;
    private float Timer = 0;
    public float speed = 5;



    public Bullet(int position /*, Tile parent, Vector3 startPos*/)
        : base(position /*, Tile parent, Vector3 startPos*/)
    {
        collide = new Collider(); //Sets a new collider
    }

    private void Start()
    {
        timeSinceLastFire = 0;


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


        if(timeSinceLastFire >= 3 && !isFiring && enemyEnter == true)
        {
            isFiring = true;
            timeSinceLastFire = 0;
        }
        else if (!isFiring)
        {
            Debug.Log(timeSinceLastFire);
            timeSinceLastFire += Time.deltaTime; 
        }
        if (firingTime <= 20 && isFiring)
        {
            GameObject bullet = Instantiate(bulletFab, transform.position + transform.up, transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300.0f);
            firingTime++;
        }
        else if (isFiring)
        {
            Debug.Log(firingTime);
            firingTime = 0;
            isFiring = false;
        }
    }



}
