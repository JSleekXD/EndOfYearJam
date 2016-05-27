using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirewallController : MonoBehaviour 
{
	public List<GameObject> p1List = new List<GameObject>();
	public List<GameObject> p2List = new List<GameObject>();


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool BuildFirewall(int playerID)
	{
		if(playerID == 0)
		{
			// DEAL WITH p1LIST
		}

		if(playerID == 1)
		{
			// DEAL WITH p2List
		}
	}
}
