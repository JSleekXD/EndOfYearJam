using UnityEngine;
using System.Collections;

public class NPCControl : MonoBehaviour {

	private GameObject npcObject;
	private NPCMovement npcMovement;
	private RuntimeVariables runtimeVariables;

	public bool isActive = false;


	// Use this for initialization
	void Start () 
	{
		npcObject = gameObject;
		npcMovement = npcObject.GetComponent<NPCMovement> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isActive)
			ProcessActions ();	
	}

	void ProcessActions()
	{
		npcMovement.Movement (npcObject);

		// Building 
		// ETC
	}
}
