using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BuildFirewall : MonoBehaviour 
{
	public int playerID; 
	public int currentLane;
	public GameObject firewallManager;
	private bool isCreated;
	private FirewallController firewallControllerScript;
	private PlayerProperties playerProperties;

	
	void Awake()
	{
		firewallControllerScript = firewallManager.GetComponent<FirewallController> ();
		playerProperties = GetComponent<PlayerProperties> ();
	}
	
	
	void Start()
	{
		playerID = playerProperties.playerID;
	}
	
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && playerID == 0)
		{
			Debug.Log("SPACE PRESSED" + playerID);
			firewallControllerScript.SelectList(playerID);
		}
		
		if(Input.GetKeyDown(KeyCode.Return) && playerID == 1)
		{
			Debug.Log("RETURN PRESSED" + playerID);
			firewallControllerScript.SelectList(playerID);
		}
	}
}