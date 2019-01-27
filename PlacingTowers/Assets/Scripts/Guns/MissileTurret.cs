using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : Turret
{
    public GameObject rocketPF;
    public float timeSinceLastFire;

    private void Start()
    {
        timeSinceLastFire = 0; //Sets the time since last fired to 0
    }

    public void FireRocket()
    {
        GameObject rocket = Instantiate(rocketPF, transform.position, transform.rotation);
        Debug.Log(enemiesInRange[0] == null);
        rocket.GetComponent<Missile>().SetTarget(enemiesInRange[0]);
        rocket.GetComponent<ProjectileBase>().damage = damage;
    }

    public void Update()
    {
        base.Update();
        if (enemiesInRange.Count > 0 && timeSinceLastFire >= fireRate)
        {
            timeSinceLastFire = 0;
            FireRocket();
        }
        else
        {
            timeSinceLastFire += Time.deltaTime;
        }
    }

}
