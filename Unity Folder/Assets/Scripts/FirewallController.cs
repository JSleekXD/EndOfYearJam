using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirewallController : MonoBehaviour 
{
	public List<GameObject> p1List = new List<GameObject>();
	public List<GameObject> p2List = new List<GameObject>();
	public int totalFirewallsPlaced = 0;

	void Update()
	{
		// SET THE SIZE EQUAL TO THE NUMBER OF ELEMENTS IN THE LIST
		for(int i = 0; i < p1List.Count; ++i)
		{
			if(p1List[i] == null)
			{
				p1List.RemoveAt(i);
			}
		}
		// SET THE SIZE EQUAL TO THE NUMBER OF ELEMENTS IN THE LIST
		for(int i = 0; i < p2List.Count; ++i)
		{
			if(p2List[i] == null)
			{
				p2List.RemoveAt(i);
			}
		}
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
