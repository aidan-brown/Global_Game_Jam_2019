using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	[SerializeField] GameObject attackTarget;
	[SerializeField] float speed = 1;
	private AudioSource audioData;
	public GameObject effect;
	private int health = 100;


	// Start is called before the first frame update
	void Start()
	{
		attackTarget = GameObject.FindGameObjectsWithTag("Earth")[0];
	}

	// Update is called once per frame
	void Update()
	{


		rotateToTarget();
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), attackTarget.transform.position, Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Earth"))
		{
			destroyShip();
			other.BroadcastMessage("TakeDamage");
		}
		else if (other.gameObject.CompareTag("PlayerBullet"))
		{
			health -= 5;
			if (health <= 0)
				destroyShip();
		}
	}

	public void changeAttackTarget(GameObject target)
	{
		attackTarget = target;
	}


	private void rotateToTarget()
	{
		Vector3 vectorToTarget = attackTarget.transform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

		Quaternion q = Quaternion.AngleAxis(angle-90, Vector3.forward);

		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
	}

	public void destroyShip()
	{

		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
