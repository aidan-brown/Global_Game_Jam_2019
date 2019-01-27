/// <summary>
/// Laser Script.
/// @author(Kobie Arndt)
/// @version(1/26/19)
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Turret
{
    public GameObject laserPrefab;
    public float timeSinceLastFire;
    private float firingTime = 0;
    public int laserDuration;
    

    private void Start()
    {
        timeSinceLastFire = 3;
        laserPrefab.GetComponent<ProjectileBase>().damage = damage;
    }

    private void Update()
    {
        base.Update();
        if(timeSinceLastFire >= fireRate && enemiesInRange.Count > 0)
        {
            laserPrefab.SetActive(true);
            timeSinceLastFire = 0;
            firingTime = 0;
            
        }
        else if (!laserPrefab.activeSelf)
        {
            timeSinceLastFire += Time.deltaTime;
        }
        else
        {
            firingTime += Time.deltaTime;
            Collider2D[] collided = new Collider2D[10];
            laserPrefab.GetComponent<BoxCollider2D>().OverlapCollider(new ContactFilter2D(), collided);
            foreach(Collider2D c in collided)
            {
                if(c != null && c.gameObject.CompareTag("Enemy"))
                {
                    c.GetComponent<EnemyController>().TakeDamage(damage);
                }
            }
        }

        if (firingTime >= laserDuration) {
            laserPrefab.SetActive(false);
        }
    }
   
}

