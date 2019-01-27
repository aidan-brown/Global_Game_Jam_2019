using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	private float timeBtwSpawn = 0;

	[SerializeField] GameObject enemy;
	[SerializeField] float spawnInterval = 1.0f;
    private GameObject earth;
    private float camMin;
	private float camMax;

	void Start()
	{
		camMin = Camera.main.orthographicSize;
		camMax = Camera.main.orthographicSize + 2;
        earth = GameObject.FindGameObjectWithTag("Earth");
        InvokeRepeating("spawnEnemy", 2.0f, spawnInterval);
	}

    // Update is called once per frame
    void Update()
    {
        if (earth == null)
        {
            Destroy(gameObject);
        }
    }

    void spawnEnemy()
	{
		float height = 2f * Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		int sign = Random.Range(0, 2) * 2 - 1;
		Vector2 v2Pos = new Vector2(Camera.main.transform.position.x + Random.Range(-width, width), Camera.main.transform.position.z + height + Random.Range(sign*10, sign*30));
		Instantiate(enemy, v2Pos, Quaternion.identity);
	}
}
