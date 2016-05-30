using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCControl : MonoBehaviour 
{
	private int playerID;
	private GameObject playerObj;
	private PlayerMovement playerMovement;
	private PlayerShooting playerShooting;
	private PlayerBuilding playerBuilding;
	private RuntimeVariables runtimeVariables;    
	
	private KeyCode ActionMoveUp;
	private KeyCode ActionMoveDown;
	private KeyCode ActionShoot;
	private KeyCode ActionBuildFirewall;
	
	public bool isControllable;
	
	public List<KeyCode> actionList;
	public float mirrorDelay = 2f;
	public float timer = 0f;

	void Start() 
	{
		playerID = GetComponent<PlayerProperties>().playerID;            
		playerObj = gameObject;
		playerMovement = GetComponent<PlayerMovement>();
		playerShooting = GetComponent<PlayerShooting>();
		playerBuilding = GetComponent<PlayerBuilding>();
		runtimeVariables = RuntimeVariables.GetInstance();

		SetupControls();
		GameObject.Find ("Player0").GetComponent<PlayerControl> ().SetNPCref (this);
		timer = mirrorDelay;
	}

	void SetupControls()
	{
		ActionMoveUp = KeyCode.W;
		ActionMoveDown = KeyCode.S;
		
		if (!runtimeVariables.isPlayer0Toggled)
		{
			ActionShoot = KeyCode.A;
			ActionBuildFirewall = KeyCode.D;
		} else {
			ActionShoot = KeyCode.D;
			ActionBuildFirewall = KeyCode.A;
		}
	}
	
	void Update() 
	{
		if (!isControllable)
			return;

		if (actionList.Count > 0) 
		{
			if (timer <= 0)
			{
				ProcessActions (actionList [0]);
			} else {
				timer -= Time.deltaTime;
			}
		}

	

	}
	
	void ProcessActions(KeyCode key)
	{
		if (key == ActionMoveUp)
		{
			playerMovement.MovePlayerUp(playerObj);
		}
		
		if (key == ActionMoveDown)
		{
			playerMovement.MovePlayerDown(playerObj);
		}
		
		if (key == ActionShoot)
		{
			playerShooting.ShootProjectile(playerObj, playerID);
		}
		
		if (key == ActionBuildFirewall)
		{
			playerBuilding.HandleBuild(playerObj, playerID, playerMovement.CurrentLane);
		}

		timer = mirrorDelay;
		actionList.RemoveAt(0);
	}
	
	public int GetPlayerID
	{
		get { return playerID; }
	}

	public void AddAction(KeyCode key)
	{
		actionList.Add(key);
	}
}
