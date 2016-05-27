using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FirewallScript : MonoBehaviour 
{
	public int firewallID;
	public List<GameObject> firewallList = new List<GameObject> ();

	private GameObject firewall;
	private PlayerProperties playerProperties;
	private PlayerMovement playerMovement;

	void Awake()
	{
		playerProperties = GameObject.FindGameObjectWithTag (TAGS.PLAYER).GetComponent<PlayerProperties> ();
		firewall = GameObject.FindGameObjectWithTag (TAGS.FIRE_WALL);
	}


	void Start()
	{
		firewallID = playerProperties.playerID;
	}


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && firewallID == 0)
		{

		}

		if(Input.GetKeyDown(KeyCode.Question) && firewallID == 1)
		{
			
		}
	}
}