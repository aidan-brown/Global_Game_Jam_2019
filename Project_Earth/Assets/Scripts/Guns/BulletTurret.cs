using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Tower
{
    public List<GameObject> enemiesInRange = new List<GameObject>();
    public GameObject bulletPrefab;
    public float timeSinceLastFire = 5.0f;
    public bool isFiring = false;
    private float firingTime = 0;

    private void Start()
    {
        timeSinceLastFire = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The object has entered the area");
        if (other.gameObject.tag == "enemy" && !enemiesInRange.Contains(other.gameObject))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        if(timeSinceLastFire >= fireRate && !isFiring && enemiesInRange.Count > 0)
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
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.up, transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300.0f);
            bullet.GetComponent<ProjectileBase>().damage = damage;
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
