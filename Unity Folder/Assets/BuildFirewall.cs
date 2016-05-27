﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BuildFirewall : MonoBehaviour 
{
	public int firewallID;
	public int playerID; 
	public int firewallCounter;
	public int maxFirewalls;
	public List<GameObject> firewallList = new List<GameObject> ();
	public int currentLane;
	
	public GameObject firewall;
	private PlayerProperties playerProperties;
	private PlayerMovement playerMovement;
	
	void Awake()
	{
		playerMovement = GameObject.FindGameObjectWithTag (TAGS.PLAYER).GetComponent<PlayerMovement> ();
		playerProperties = GameObject.FindGameObjectWithTag (TAGS.PLAYER).GetComponent<PlayerProperties> ();
	}
	
	
	void Start()
	{
		playerID = playerProperties.playerID;
		maxFirewalls = 8;
	}
	
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && playerID == 0)
		{
			Debug.Log("SPACE PRESSED");
			CreateFirewall();
		}
		
		if(Input.GetKeyDown(KeyCode.Return) && playerID == 1)
		{
			Debug.Log("QUESTION PRESDSED");
			CreateFirewall();
		}
	}
	
	
	void CreateFirewall()
	{
		// CAN YOU FIRE
		//if (firewallList.Count < maxFirewalls) 
	//	{
			if (playerID == 0)
			{
				GameObject firewallClone = (GameObject)Instantiate (firewall, new Vector3 (transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
				firewallList.Add (firewallClone);
			}
			
			if (playerID == 1)
			{
				GameObject firewallClone = (GameObject)Instantiate (firewall, new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z), transform.rotation);
				firewallList.Add (firewallClone);
			}
	//	}
		//else
		//{
			// PLAY MUSIC

		//}
	}
}