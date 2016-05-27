using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

	public float countdown = 0f;
	public float countdownThreshold = 3f;
	public int projectileID;

	private BuildFirewall buildFirewall;
	private SceneManager sceneManagerScript;


	void Awake()
	{
		sceneManagerScript = GameObject.FindGameObjectWithTag (TAGS.SCENEMANAGER).GetComponent<SceneManager> (); 
		buildFirewall = GameObject.FindGameObjectWithTag (TAGS.PLAYER).GetComponent<BuildFirewall> ();
	}

	// Update is called once per frame
	void Update () {

		countdown += Time.deltaTime;

		if (countdown >= countdownThreshold) {
			RemoveSelfFromList();
			//Destroy (gameObject);
		}
	}

//	void OnCollisionEnter2D(Collision2D collision){
//		if (collision.gameObject.tag == "PROJECTILE") {
//
//		} else {
//			Destroy (gameObject);
//		}
//	}

	public void RemoveSelfFromList(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("PLAYER");
		for(int i = 0; i < players.Length; i++){
			if(players[i].GetComponent<PlayerProperties>().playerID == projectileID){
				
				players[i].GetComponent<PlayerFiring>().RemoveProjectilefromList();
				Destroy (gameObject);
				return;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "PROJECTILE") 
		{
			if (collider.gameObject.GetComponent<Projectile> ().projectileID == projectileID) 
			{

			} 
			else 
			{
				RemoveSelfFromList ();
			}
		} 
		else if (collider.gameObject.tag == "PLAYER") 
		{
			RemoveSelfFromList ();
		}
		else if (collider.gameObject.tag == "FIREWALL") 
		{
			// IGNORE OWN FIREWALLS
			if (collider.gameObject.GetComponent<FirewallSpecs>().firewallID != projectileID)
			{
				RemoveSelfFromList ();

				if(collider.gameObject.GetComponent<FirewallSpecs>().firewallID == 0)
				{
					sceneManagerScript.p1totalFirewalls--;
				}

				if(collider.gameObject.GetComponent<FirewallSpecs>().firewallID == 1)
				{
					sceneManagerScript.p2totalFirewalls--;
				}

				Destroy(collider.gameObject);
			}
		}
	}
}