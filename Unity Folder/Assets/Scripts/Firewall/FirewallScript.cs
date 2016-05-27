using UnityEngine;
using System.Collections;

public class FirewallScript : MonoBehaviour 
{
	public bool isInstantiated = false;

	private GameObject[] firewallArray;
	private GameObject firewall;
	private PlayerMovement playerMovement;

	void Awake()
	{
		playerMovement = GameObject.FindGameObjectWithTag (TAGS.PLAYER).GetComponent<PlayerMovement> ();
		firewall = GameObject.FindGameObjectWithTag (TAGS.FIRE_WALL);
	}

	void Start()
	{

	}

	void Update()
	{
		// IF FIREWALLS ARE NOT INSTANTIATED
		if (!isInstantiated) 
		{
			LoadFirewalls();
			isInstantiated = true;
		}
	}

	void LoadFirewalls()
	{
		// INSTANTIATE FIRE WALLS
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


