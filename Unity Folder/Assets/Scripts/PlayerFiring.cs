using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFiring : MonoBehaviour {

    // Use this for initialization

    public GameObject projectile;
	public int maxProjectiles = 3;
	public int speed = 500;
	public int playerID = 0;
	public List<GameObject> projectileList = new List<GameObject>();
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.A)){
			if(projectileList.Count < maxProjectiles){
			FireProjectile(projectile);
			}
		}
	}

	public void FireProjectile(GameObject projectile){


		GameObject projectileClone = (GameObject)Instantiate (projectile, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z ), transform.rotation);
		projectileClone.GetComponent<Projectile> ().projectileID = playerID;
		projectileList.Add (projectileClone);
		projectileClone.GetComponent<Rigidbody2D>().AddForce (new Vector2(1,0) * speed);

		Debug.Log (projectileList.Count);
	}

	public void RemoveProjectilefromList(){
		projectileList.RemoveAt (0);
	}



}
