using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : Turret
{
    public GameObject bulletPrefab;
    public float timeSinceLastFire = 5.0f;
    public int roundsPerSpray;
    private int bulletsFired;

    private void Start()
    {
        bulletsFired = roundsPerSpray;
    }

    private void Update()
    {
        base.Update();
        if (timeSinceLastFire >= fireRate && enemiesInRange.Count > 0)
        {
            timeSinceLastFire = 0;
            bulletsFired = 0;
        }
        else
        {
            timeSinceLastFire += Time.deltaTime;
        }

        if (bulletsFired < roundsPerSpray)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 300.0f);
            bullet.GetComponent<ProjectileBase>().damage = damage;
            bulletsFired++;
        }
    }
}
