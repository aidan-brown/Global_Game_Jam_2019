using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public int damage;
    public bool destroyOnHit;
    private float timer = 0;

    private void Update()
    {
        if (destroyOnHit)
        {
            timer += Time.deltaTime;
            if (timer >= 10)
                Destroy(gameObject);
        }
    }
}
