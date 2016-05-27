using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FirewallScript : MonoBehaviour 
{
	public GameObject fireWalls;
	private PlayerMovement playerMovement;
	public int numOfFirewalls;

	void Start()
	{
		playerMovement = GameObject.FindGameObjectWithTag (TAGS.PLAYER).GetComponent<PlayerMovement> ();
		numOfFirewalls = playerMovement.deskArray.Length * 2;
	}


	void Update()
	{
	}
}
