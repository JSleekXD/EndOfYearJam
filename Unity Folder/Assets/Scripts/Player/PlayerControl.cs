using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour 
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

	private float firewallTimer =0;
	private float firewallTimerThreshold = .5f;
	private bool  isPlayerBuildingFirewall = false;
	public List<GameObject> playerComputers;
	private bool stopDeterminingFill = false;

	public PlayerAudioManager audioManager;


	private NPCControl npcRef;
    
    void Start() 
    {
        playerID = GetComponent<PlayerProperties>().playerID;            
        playerObj = gameObject;
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponent<PlayerShooting>();
        playerBuilding = GetComponent<PlayerBuilding>();
        runtimeVariables = RuntimeVariables.GetInstance();
		//audioManager = transform.Find("PlayerAudioManager").transform.GetComponent<PlayerAudioManager> ();
		audioManager.StopFirewallBuildingSound ();
        SetupControls();
		SetupComputers ();
    }
	
	void Update() 
    {
        if (!isControllable)
            return;
            
        ProcessActions();
	}

	void SetupComputers(){

		List<GameObject> leftComputers = GameObject.Find ("SceneManager").GetComponent<SceneManager> ().leftComputers;
		List<GameObject> rightComputers = GameObject.Find ("SceneManager").GetComponent<SceneManager> ().rightComputers;

		if (playerID == 0) {
			for(int i = 0; i < leftComputers.Count; i++)
			{
				playerComputers.Add(leftComputers[i]);
			}

		}
		if (playerID == 1) {
			for(int i = 0; i < rightComputers.Count; i++)
			{
				playerComputers.Add(rightComputers[i]);
			}
	
		}
	}
    
    void SetupControls()
    {
        Player0Controls();
        Player1Controls();
    }
    
    void Player0Controls()
    {
        if (playerID == 0)
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
    }
    
    void Player1Controls()
    {
        if (playerID == 1)
        {
            ActionMoveUp = KeyCode.UpArrow;
            ActionMoveDown = KeyCode.DownArrow;
            
			if (!runtimeVariables.isPlayer1Toggled)
            {
                ActionShoot = KeyCode.LeftArrow;
                ActionBuildFirewall = KeyCode.RightArrow;
            } else {
                ActionShoot = KeyCode.RightArrow;
                ActionBuildFirewall = KeyCode.LeftArrow;
            }
        }
    }
    
    void ProcessActions()
    {
		if (Input.GetKeyDown(ActionMoveUp))
        {
			PassActionToNPC(ActionMoveUp);

			ResetBuildTimer();
            playerMovement.MovePlayerUp(playerObj);
        }
        
		if (Input.GetKeyDown(ActionMoveDown))
        {
			PassActionToNPC(ActionMoveDown);

			ResetBuildTimer();
            playerMovement.MovePlayerDown(playerObj);
        }
        
        if (Input.GetKeyDown(ActionShoot))
        {
			PassActionToNPC(ActionShoot);

            playerShooting.ShootProjectile(playerObj, playerID);
        }
        
        if (Input.GetKey(ActionBuildFirewall))
        {
			CheckFirewallsInLane();
			ChangeComputerFirewallFill(playerMovement.CurrentLane);
			if (Input.GetKeyDown(ActionBuildFirewall))
				PassActionToNPC(ActionBuildFirewall);

			isPlayerBuildingFirewall = true;
			firewallTimer += Time.deltaTime;
			if (firewallTimer >= firewallTimerThreshold)
			{
				playerBuilding.HandleBuild(playerObj, playerID, playerMovement.CurrentLane);
				ResetBuildTimer();
			}  
        }
		else
		{
			audioManager.StopFirewallBuildingSound ();
		//	playerComputers [GetComponent<PlayerMovement>().CurrentLane].GetComponentInChildren<Image> ().fillAmount = 0;

				ResetBuildTimer();
		}
    }

	void ChangeComputerFirewallFill(int currentLane){
		CheckFirewallsInLane ();
		if (stopDeterminingFill == false) {
			//Debug.Log ("CALLED");
			audioManager.PlayFirewallBuildingSound ();
			playerComputers [currentLane].transform.Find ("ComputerScreenFirewall").GetComponent<Image> ().fillAmount = (firewallTimer / firewallTimerThreshold);
		} else {
			audioManager.StopFirewallBuildingSound ();
		}
	}

	void CheckFirewallsInLane(){
		if (GetComponent<PlayerBuilding> ().FirewallsInLane (GetComponent<PlayerMovement> ().CurrentLane) == GetComponent<PlayerBuilding> ().MAX_FIREWALLS_PER_LANE) {
			playerComputers [GetComponent<PlayerMovement> ().CurrentLane].transform.Find ("ComputerScreenFirewall").GetComponent<Image> ().fillAmount = 1;
			stopDeterminingFill = true;
			audioManager.StopFirewallBuildingSound ();
		} else {
			stopDeterminingFill = false;
		}
	}
    
    public void ResetBuildTimer()
    {


		isPlayerBuildingFirewall = false;
		firewallTimer = 0f;
		CheckFirewallsInLane ();
		if (stopDeterminingFill == false) {
			playerComputers [GetComponent<PlayerMovement> ().CurrentLane].transform.Find ("ComputerScreenFirewall").GetComponent<Image> ().fillAmount = 0;
		}
    }

	public int GetPlayerID
	{
		get { return playerID; }
	}

	void PassActionToNPC(KeyCode key)
	{
		if (!npcRef)
			return;

		npcRef.AddAction(key);
	}

	public void SetNPCref(NPCControl reference)
	{
		npcRef = reference;
	}
}
