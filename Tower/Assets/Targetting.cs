using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    public CircleCollider2D collider;
    public GameObject rocketPF;
    public bool enemyEntered;
    public GameObject target;
    public GameObject spawnPoint;
    public float timeSinceLastFire = 3;


    public void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.isTrigger = true;
    }

    public void FireRocket(GameObject target)
    {
        GameObject rocket = Instantiate(rocketPF, transform);
        rocket.GetComponent<Missile>().SetTarget(target);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            enemyEntered = true;
            target = collision.gameObject;
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            enemyEntered = false;
        }
    }

    public void Update()
    {
        if (enemyEntered && timeSinceLastFire >= 2)
        {
            timeSinceLastFire = 0;
            FireRocket(target);
        }
        else
        {
            timeSinceLastFire += Time.deltaTime;
        }
    }

}
