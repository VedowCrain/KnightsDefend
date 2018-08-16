using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReactor : MonoBehaviour
{

	public Color healthy, littleInjured, veryInjured, dead;
	private Player player;
	private MeshRenderer rend;

	private void Start()
	{
		player = FindObjectOfType<Player>();
		rend = GetComponent<MeshRenderer>();
	}


	private void FixedUpdate()
	{
		if (player.health > 75 && player.health <= 100)
			rend.material.color = healthy;
		
		else if (player.health > 50 && player.health <= 75)
			rend.material.color = littleInjured;
		
		else if (player.health > 25 && player.health <= 50)
			rend.material.color = veryInjured;
		
		else if (player.health > 0 && player.health <= 25)
			rend.material.color = dead;
	}
}
