using UnityEngine;
using System.Collections;

public class FirewallScript : MonoBehaviour 
{
	public bool isInstantiated = false;

	private GameObject[] firewallArray;
	private GameObject firewall;
	private PlayerMovement playerMovement;
	private int firewallID;

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
		// CREATE AMOUNT OF FIRE WALLS
		for(int i = 0; i < (playerMovement.deskArray.Length * 4); ++i)
		{
			// FIRST ROW
			if(i <= playerMovement.deskArray.Length)
			{
				CreateFirewallObj(
			}
		}
	}

	void CreateFirewallObj(int position)
	{
		// PLACE FIREWALLS AT POSITION AND GIVE THE FIREWALLS A ID
		GameObject firewallClone = (GameObject)Instantiate (firewall, new Vector2 (transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
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


