using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FirewallScript : MonoBehaviour 
{
	public bool isInstantiated = false;

	private GameObject[] firewallArray;
	private GameObject firewall;
	private PlayerProperties playerProperties;
	public int firewallID;

	void Awake()
	{
		//playerProperties = GameObject.FindGameObjectWithTag (TAGS.PLAYER).GetComponent<Player> ();
		firewall = GameObject.FindGameObjectWithTag (TAGS.FIRE_WALL);
	}

	void Start()
	{
		//firewallID = GetComponent
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

	}

	void CreateFirewallObj()
	{
		// PLACE FIREWALLS AT POSITION AND GIVE THE FIREWALLS A ID
		//GameObject firewallClone = (GameObject)Instantiate (firewall, new Vector2 (transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
		// SET ID
		//projectileList.Add (projectileClone);
	}
}


	/*
		if (playerID == 0) 
		{
			transform.position = new Vector2 (deskArray [0].transform.position.x - 5, 0);
		}
		if (playerID == 1)
		{
			transform.position = new Vector2 (deskArray [0].transform.position.x + 5, 0);
		}
 */


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


