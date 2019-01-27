/**Code referenced from 
 * Wabble Unity Tutorials 
 * on Youtube
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : ProjectileBase
{
    public float speed = 3;
    public float rotatingSpeed = 200;
    public GameObject target;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 pointToTarget = (Vector2)transform.position - (Vector2)target.transform.position;

        pointToTarget.Normalize();
        float value = Vector3.Cross(pointToTarget, transform.right).z;

        if (value > 0)
        {
            rb.angularVelocity = rotatingSpeed;
        }
        else if (value < 0)
        {
            rb.angularVelocity = -rotatingSpeed;
        }
        else
        {
            rotatingSpeed = 0;
        }
        rb.velocity = transform.right * speed;
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
        Debug.Log("The target was set");
    }
}
