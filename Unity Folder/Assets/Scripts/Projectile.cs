using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float countdown = 0f;
	public float countdownThreshold = 3f;
	public int projectileID;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		countdown += Time.deltaTime;

		if (countdown >= countdownThreshold) {
			Destroy (gameObject);
		}
	}

//	void OnCollisionEnter2D(Collision2D collision){
//		if (collision.gameObject.tag == "PROJECTILE") {
//
//		} else {
//			Destroy (gameObject);
//		}
//	}
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "PROJECTILE") {
			if(collider.gameObject.GetComponent<Projectile>().projectileID == projectileID)
			{}else{Destroy(gameObject);}

		} else if (collider.gameObject.tag == "PLAYER") {

			GameObject[] players = GameObject.FindGameObjectsWithTag("PLAYER");
			for(int i = 0; i < players.Length; i++){
				if(players[i].GetComponent<PlayerFiring>().playerID == projectileID){

						players[i].GetComponent<PlayerFiring>().RemoveProjectilefromList();
						Destroy (gameObject);
						return;
				}		
		}
	  }
}
}