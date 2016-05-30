using UnityEngine;
using System.Collections;

public class NPCControl : MonoBehaviour 
{
	private int npcID;
	private GameObject npcObject;
	private NPCMovement npcMovement;
	private NPCShoot npcShoot;
	private RuntimeVariables runtimeVariables;

	public bool isControllable;


	// Use this for initialization
	void Start () 
	{
		npcID = GetComponent<NPCProperties> ().npcID;
		npcMovement = GetComponent<NPCMovement> ();
		npcShoot = GetComponent<NPCShoot> ();
		npcObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isControllable)
			return;

		ProcessActions ();
	}

	void ProcessActions()
	{
		npcMovement.Movement (npcObject);
		npcShoot.ShootingProjectiles(npcObject, npcID);

		// Building 
		// ETC
	}
}
