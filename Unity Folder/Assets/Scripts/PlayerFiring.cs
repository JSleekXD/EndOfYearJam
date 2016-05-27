using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFiring : MonoBehaviour {

    // Use this for initialization

    public GameObject projectile;
	public int maxProjectiles = 3;
	public int speed = 500;
	private int playerID;
	public List<GameObject> projectileList = new List<GameObject>();
    
    private KeyCode player1Fire;
    private KeyCode player2Fire;
    
	void Start () 
	{
		playerID = GetComponent<PlayerProperties> ().playerID;
        
        ToggleManager toggleManager = GameObject.Find("ToggleManager").GetComponent<ToggleManager>();
        
        if (!toggleManager.isPlayer1Toggled)
            player1Fire = KeyCode.A;
        else
            player1Fire = KeyCode.D;
            
        if (!toggleManager.isPlayer2Toggled)
            player2Fire = KeyCode.LeftArrow;
        else
            player2Fire = KeyCode.RightArrow;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(player1Fire) && playerID == 0)
		{
			if(projectileList.Count < maxProjectiles)
			{
				FireProjectile(projectile);
			}
		}
        
		if (Input.GetKeyDown(player2Fire) && playerID == 1) 
		{
			if(projectileList.Count < maxProjectiles)
			{
				FireProjectile(projectile);
			}
		}
	}

	public void FireProjectile(GameObject projectile)
	{
		if (playerID == 0) 
		{
			GameObject projectileClone = (GameObject)Instantiate (projectile, new Vector3 (transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
			projectileClone.GetComponent<Projectile> ().projectileID = playerID;
			projectileList.Add (projectileClone);
			projectileClone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1, 0) * speed);
		} 
		else if (playerID == 1) 
		{
			GameObject projectileClone = (GameObject)Instantiate (projectile, new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z), transform.rotation);
			projectileClone.GetComponent<Projectile> ().projectileID = playerID;
			projectileList.Add (projectileClone);
			projectileClone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-1, 0) * speed);
		}
	}

	public void RemoveProjectilefromList()
	{
		projectileList.RemoveAt (0);
	}
}
