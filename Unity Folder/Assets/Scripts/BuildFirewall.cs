using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BuildFirewall : MonoBehaviour 
{
	public int playerID; 
	public int currentLane;
	public GameObject firewallManager;
	public List<GameObject> firewallList = new List<GameObject> ();
	public GameObject firewallObject;

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
			Debug.Log("SPACE PRESSED" + firewallList.Count);
			firewallList = firewallControllerScript.SelectList(playerID);
		}
		
		if(Input.GetKeyDown(KeyCode.Return) && playerID == 1)
		{
			Debug.Log("RETURN PRESSED" + firewallList.Count);
			firewallList = firewallControllerScript.SelectList(playerID);
		}
	}

	bool ListCountCheck(int playerID)
	{
		if (firewallList.Count == 0) 
		{
			// ADD ONE TO THE DESK AT x POSITION
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
			GameObject p1Firewall = (GameObject)Instantiate (firewallObject, new Vector3 (transform.position.x + positionValue, transform.position.y, transform.position.z), transform.rotation);
			firewallList.Add(p1Firewall); // PUSH OBJECT INTO LIST
			break;
		case 1:
			GameObject p2Firewall = (GameObject)Instantiate (firewallObject, new Vector3 (transform.position.x - positionValue, transform.position.y, transform.position.z), transform.rotation);
			firewallList.Add(p2Firewall); // PUSH OBJECT INTO LIST
			break;
		}
	}
}