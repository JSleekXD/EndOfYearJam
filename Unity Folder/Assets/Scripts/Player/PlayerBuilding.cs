﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBuilding : MonoBehaviour 
{
	public List<List<GameObject>> firewalls = new List<List<GameObject>>();
    public GameObject firewallRef;
    public int maxFirewalls = 8;
    public int currentFirewalls = 0;
    
    public  int MAX_FIREWALLS_PER_LANE = 3;
    private const int BASE_OFFSET_X = 2;
    
	void Start() 
	{
        CreateLists();
	}
    
    void CreateLists()
    {
        int numDesks = GameObject.Find("SceneManager").GetComponent<SceneManager>().DesksCount;
        for (int i = 0; i < numDesks; ++i)
        {
            firewalls.Add(new List<GameObject>());
        }
    }
    
    public void HandleBuild(GameObject player, int playerID, int currentLane)
    {
        CountFirewalls();
        PlaceFirewall(player, playerID, currentLane);
    }
    
    void CountFirewalls()
    {
        currentFirewalls = 0;
        foreach (var list in firewalls)
        {
            currentFirewalls += list.Count;
        }
    }
	public int FirewallsInLane (int currentLane){
		return firewalls [currentLane].Count;
	}

    void PlaceFirewall(GameObject player, int playerID, int currentLane)
	{
        if (currentFirewalls == maxFirewalls)
            return;
            
        int numFirewalls = firewalls[currentLane].Count;
        if (numFirewalls == MAX_FIREWALLS_PER_LANE)
            return;
        
        float offsetX = BASE_OFFSET_X + numFirewalls;
        if (playerID == 1)
            offsetX = -offsetX;
            
        GameObject newFirewall = Instantiate(firewallRef);
        newFirewall.name = "Player" + playerID + "Firewall";
        newFirewall.transform.position = new Vector2(gameObject.transform.position.x + offsetX, gameObject.transform.position.y);
        
        firewalls[currentLane].Add(newFirewall);
    }
    
    public void RemoveWall(GameObject wall, int lane)
    {
        firewalls[lane].Remove(wall);        
        Destroy(wall);
    }
}
