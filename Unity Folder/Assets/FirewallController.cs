using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirewallController : MonoBehaviour 
{
	public List<GameObject> p1List = new List<GameObject>();
	public List<GameObject> p2List = new List<GameObject>();

	public GameObject firewall;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool SelectList(int playerID)
	{
		bool isPlaced = false;

		if (playerID == 0) 
		{
			isPlaced = ListCountCheck (p1List, playerID);
		}

		if (playerID == 1) 
		{
			isPlaced = ListCountCheck (p2List, playerID);
		}

		// CHECK IF THE FIREWALL CAN BE PLACED
		if (isPlaced) 
			return true;
		else
			return false;
	}

	bool ListCountCheck(List<GameObject> list, int playerID)
	{
		if (list.Count == 0) 
		{
			// ADD ONE TO THE DESK AT x POSITION
			PlaceFirewall(list, 0, playerID, 2);
		}
		else if(list.Count == 1)
		{
			// ADD ONE TO THE DESK AT x + 1 POSITION
		}
		else if(list.Count == 2)
		{
			// ADD ONE TO THE DESK AT x + 2 POSITION
		}
		else
		{
			// FIREWALL CANNOT BE PLACED
			return false;
		}

		return true;
	}

	void PlaceFirewall(List<GameObject> list, int listPos, int playerID, int positionValue)
	{
		switch (playerID) 
		{
		case 0:
			GameObject p1Firewall = (GameObject)Instantiate (firewall, new Vector3 (transform.position.x + positionValue, transform.position.y, transform.position.z), transform.rotation);
			list [listPos] = p1Firewall; // PUSH OBJECT INTO LIST
			break;
		//	firewellClone.GetComponent<Projectile> ().projectileID = playerID;
		case 1:
			GameObject p2Firewall = (GameObject)Instantiate (firewall, new Vector3 (transform.position.x - positionValue, transform.position.y, transform.position.z), transform.rotation);
			list [listPos] = p2Firewall; // PUSH OBJECT INTO LIST
			break;
		}
	}
}
