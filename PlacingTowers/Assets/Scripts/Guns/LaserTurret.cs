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
    public float timeSinceLastFire = 3.0f;
    private bool isFiring = false;
    private float firingTime = 0;

    private void Start()
    {
        timeSinceLastFire = 0; //Sets the time since last fired to 0
        laserPrefab.GetComponent<ProjectileBase>().damage = damage;
    }

    private void Update()
    {
        base.Update();
        if (timeSinceLastFire >= fireRate && !isFiring && enemiesInRange.Count > 0)
        {
            isFiring = true;
            timeSinceLastFire = 0;
        }
        else if (!isFiring)
        {
            Debug.Log(timeSinceLastFire);
            timeSinceLastFire += Time.deltaTime;
        }

        if (firingTime < fireRate && isFiring)
        {
            laserPrefab.SetActive(true);
            firingTime += Time.deltaTime;
        }
        else if (isFiring)
        {
            Debug.Log(firingTime);
            firingTime = 0;
            isFiring = false;
            laserPrefab.SetActive(false);
        }
    }
   
}

