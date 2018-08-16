using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
	private float speed;
	
	// Use this for initialization
	void Start ()
	{
		speed = Random.Range(1f, 5f);
		
		InvokeRepeating("FindPlayer", 2, 2);
	}

	void FindPlayer()
	{
		GetComponent<NavMeshAgent>().SetDestination(FindObjectOfType<Player>().transform.position);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
