using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BuildFirewall : MonoBehaviour 
{
	public int playerID; 
	public int currentLane;
	public List<GameObject> firewallList = new List<GameObject> ();
	public GameObject firewallObject;


	//public int playerOneTotalFirewalls;
	//public int playerTwoTotalFirewalls;
	public const int MAX_FIREWALLS = 8;

	private bool cannotPlace;
	private FirewallController firewallControllerScript;
	private PlayerProperties playerProperties;
	private PlayerMovement playerMovement;
	private SceneManager sceneManagerScript;

	
	void Awake()
	{
		sceneManagerScript = GameObject.FindGameObjectWithTag (TAGS.SCENEMANAGER).GetComponent<SceneManager> ();
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


		if (Input.GetKeyDown (KeyCode.Space) && playerID == 0) 
		{
			if(sceneManagerScript.p1totalFirewalls < MAX_FIREWALLS)
			{
				// get the firewallControllerScript on the lane that the player is on. 
				firewallControllerScript = playerMovement.deskArray [currentLane].GetComponent<FirewallController> (); 

				// Print the current lane value and the player ID value
				Debug.Log ("PLAYER ID: " + playerID + "CURRENT LANE: " + playerMovement.currentLane);

				// Get the correct list on that lane. 
				firewallList = firewallControllerScript.SelectList (playerID);

				ListCountCheck (playerID);
			}
			else
			{
				cannotPlace = true;
			}
		}		

		if (Input.GetKeyDown (KeyCode.Return) && playerID == 1) 
		{
			if(sceneManagerScript.p2totalFirewalls < MAX_FIREWALLS)
			{
				// get the firewallControllerScript on the lane that the player is on. 
				firewallControllerScript = playerMovement.deskArray [currentLane].GetComponent<FirewallController> (); 
		
				// Print the current lane value and the player ID value
				Debug.Log ("PLAYER ID: " + playerID + "CURRENT LANE: " + playerMovement.currentLane);

				// Get the correct list on that lane. 
				firewallList = firewallControllerScript.SelectList (playerID);
		
				ListCountCheck (playerID);
			}
			else
			{
				cannotPlace = true;
			}
		}
	

		if(cannotPlace)
		{
			// PLAYER CANNOT PLACE SFX
		}

		cannotPlace = false;
	}

	// CHECK THE FIREWALLS POSITION IN THE LIST GIVE IT A VALUE TO BE PLACED AT
	void ListCountCheck(int playerID)
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
	}
	
	void PlaceFirewall(int playerID, int positionValue)
	{
		switch (playerID) 
		{
		case 0:
			Debug.Log("placing player 0");
			GameObject p1Firewall = (GameObject)Instantiate (firewallObject, new Vector3 (transform.position.x + positionValue, transform.position.y, transform.position.z), transform.rotation);
			p1Firewall.GetComponent<FirewallSpecs>().firewallID = playerID;		// SET FIREWALL TAG
			firewallList.Add(p1Firewall);										// PUSH OBJECT INTO LIST
			//playerOneTotalFirewalls++;											// INCREMENT COUNTER
			sceneManagerScript.p1totalFirewalls++;
			break;
		case 1:
			Debug.Log("placing player 1");
			GameObject p2Firewall = (GameObject)Instantiate (firewallObject, new Vector3 (transform.position.x - positionValue, transform.position.y, transform.position.z), transform.rotation);
			p2Firewall.GetComponent<FirewallSpecs>().firewallID = playerID;		// SET FIREWALL TAG
			firewallList.Add(p2Firewall);										// PUSH OBJECT INTO LIST
			//playerTwoTotalFirewalls++;											// INCREMENT COUNTER
			sceneManagerScript.p2totalFirewalls++;
			break;
		}
	}

	public void DecrementCounter(int firewallID)
	{
		
	}
}