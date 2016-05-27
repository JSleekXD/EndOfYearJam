using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BuildFirewall : MonoBehaviour 
{
	public int playerID; 
	public int currentLane;
	public List<GameObject> firewallList = new List<GameObject> ();
	public GameObject firewallObject;

	private bool isCreated;
	private FirewallController firewallControllerScript;
	private PlayerProperties playerProperties;
	private PlayerMovement playerMovement;

	
	void Awake()
	{
		playerProperties = GetComponent<PlayerProperties> ();
		playerMovement = GetComponent<PlayerMovement> ();
	}
	
	
	void Start()
	{
		playerID = playerProperties.playerID;
	}
	
	
	void Update()
	{
		currentLane = playerMovement.currentLane;

		if(Input.GetKeyDown(KeyCode.Space) && playerID == 0)
		{
			// get the firewallControllerScript on the lane that the player is on. 
			firewallControllerScript =	playerMovement.deskArray[currentLane].GetComponent<FirewallController> (); 

			// Print the current lane value and the player ID value
			Debug.Log("PLAYER ID: " + playerID + "CURRENT LANE: " + playerMovement.currentLane);

			// Get the correct list on that lane. 
			firewallList = firewallControllerScript.SelectList(playerID);

			ListCountCheck(playerID);
		}
		
		if(Input.GetKeyDown(KeyCode.Return) && playerID == 1)
		{
			// get the firewallControllerScript on the lane that the player is on. 
			firewallControllerScript =	playerMovement.deskArray[currentLane].GetComponent<FirewallController> (); 
			
			// Print the current lane value and the player ID value
			Debug.Log("PLAYER ID: " + playerID + "CURRENT LANE: " + playerMovement.currentLane);
			
			// Get the correct list on that lane. 
			firewallList = firewallControllerScript.SelectList(playerID);
		
			ListCountCheck(playerID);
		}
	}

	bool ListCountCheck(int playerID)
	{
		if (firewallList.Count == 0) 
		{
			PlaceFirewall(playerID, 2);
		}
		else if(firewallList.Count == 1)
		{
			PlaceFirewall(playerID, 3);
		}
		else if(firewallList.Count == 2)
		{
			PlaceFirewall(playerID, 4);
		}
		else
		{
			// FIREWALL CANNOT BE PLACED
			return false;
		}
		
		return true;
	}
	
	void PlaceFirewall(int playerID, int positionValue)
	{
		switch (playerID) 
		{
		case 0:
			Debug.Log("placing player 0");
			GameObject p1Firewall = (GameObject)Instantiate (firewallObject, new Vector3 (transform.position.x + positionValue, transform.position.y, transform.position.z), transform.rotation);
			firewallList.Add(p1Firewall); // PUSH OBJECT INTO LIST
			break;
		case 1:
			Debug.Log("placing player 1");
			GameObject p2Firewall = (GameObject)Instantiate (firewallObject, new Vector3 (transform.position.x - positionValue, transform.position.y, transform.position.z), transform.rotation);
			firewallList.Add(p2Firewall); // PUSH OBJECT INTO LIST
			break;
		}
	}
}