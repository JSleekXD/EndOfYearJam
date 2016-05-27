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

	public List<GameObject> SelectList(int playerID)
	{
		List<GameObject> temp = new List<GameObject> ();

		switch (playerID) 
		{
		case 0:
			temp = p1List;
			break;
		case 1:
			temp = p2List;
			break;
		}
		return temp;
	}
}
