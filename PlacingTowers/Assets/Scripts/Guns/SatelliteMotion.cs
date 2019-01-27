using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Turret))]
public class SatelliteMotion : MonoBehaviour
{
    /// <summary>
    /// The tower currently attached to this object
    /// </summary>
    Turret t;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        if(t.enemiesInRange.Count > 0)
        {
            rotateToTarget();
        }
    }

    private void rotateToTarget()
    {
        Vector3 vectorToTarget = t.enemiesInRange[0].transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
    }
}
