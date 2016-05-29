using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	private int playerID;
	private float speed;
    private int currentLane;
    
	void Update()
	{
		gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        string otherTag = other.gameObject.tag;
        string otherName = other.gameObject.name;
        
		if (otherTag == "Player")
		{
            // Ignore collisions with the shooting player
			if (other.gameObject.GetComponent<PlayerProperties>().playerID == playerID)
				return;
		}
        
        if (otherTag == "Projectile")
        {
            // Ignore collisions with other projectiles from the shooting player
            if (other.gameObject.GetComponent<Projectile>().playerID == playerID)
                return;
        }
        
        if (otherTag == "Firewall")
        {
            // Ignore collisions with firewalls created by the shooting player
            if (otherName == "Player" + playerID + "Firewall")
                return;
            
            // Determine which player owns the firewall and remove it from their list
            int targetID = playerID == 0 ? 1 : 0;
            GameObject.Find("Player" + targetID).GetComponent<PlayerBuilding>().RemoveWall(other.gameObject, currentLane);
        }   

        GameObject.Find("Player" + playerID).GetComponent<PlayerShooting>().RemoveProjectile(gameObject);
	}
    
    public void SetProperties(int id, float spd, int lane)
    {
        playerID = id;
        speed = spd;
        currentLane = lane;
    }
    
    public int PlayerID
    {
        get { return playerID; }
    }
}
