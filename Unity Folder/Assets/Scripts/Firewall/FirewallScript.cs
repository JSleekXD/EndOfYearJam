using UnityEngine;
using System.Collections;

public class FirewallScript : MonoBehaviour 
{

	void Start()
	{

	}

	void Update()
	{
		// IF FIREWALLS ARE NOT INSTANTIATED

	}

}



/*
	private PlayerFiring playerFiringScript;
	private GameObject player;

	// Use this for initialization
	void Awake () 
	{
		gameObject.SetActive(true);
	}
	
	void Start () 
	{
		player				= GameObject.FindGameObjectWithTag (TAGS.PLAYER);
		playerFiringScript	= player.GetComponent<PlayerFiring> ();
	}


	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "PROJECTILE")
		{
			// DISAPPEAR
			gameObject.SetActive(false);
		}
	}
	*/


