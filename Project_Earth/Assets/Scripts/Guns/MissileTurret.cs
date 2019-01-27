using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : Tower
{
    public GameObject rocketPF;
    public List<GameObject> enemiesInRange = new List<GameObject>();
    public GameObject target;
    public float timeSinceLastFire = 3;

    private void Start()
    {
        timeSinceLastFire = 0; //Sets the time since last fired to 0
    }

    public void FireRocket(GameObject target)
    {
        GameObject rocket = Instantiate(rocketPF, transform);
        rocket.GetComponent<Missile>().SetTarget(target);
        rocket.GetComponent<ProjectileBase>().damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The object has entered the area");
        if (other.gameObject.tag == "enemy" && !enemiesInRange.Contains(other.gameObject))
        {
            if(target == null)
                target = other.gameObject;
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemiesInRange.Remove(other.gameObject);
            if (target == other.gameObject)
            {
                target = null;
                if (enemiesInRange.Count != 0)
                    target = enemiesInRange[0];
            }
        }
    }

    public void Update()
    {
        if (enemiesInRange.Count > 0 && timeSinceLastFire >= fireRate)
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
