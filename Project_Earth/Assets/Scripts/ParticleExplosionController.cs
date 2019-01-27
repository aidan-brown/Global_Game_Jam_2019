using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalExplostionController : MonoBehaviour
{
    private ParticleSystem parts;
    private float totalDuration;

    void Start()
    {
       parts  = gameObject.GetComponent<ParticleSystem>();
        totalDuration = parts.duration + parts.startLifetime;
        Destroy(gameObject, totalDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
