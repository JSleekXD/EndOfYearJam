using UnityEngine;
using System.Collections;

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
    
    void Start() 
    {
        playerID = GetComponent<PlayerProperties>().playerID;            
        playerObj = gameObject;
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponent<PlayerShooting>();
        playerBuilding = GetComponent<PlayerBuilding>();
        runtimeVariables = RuntimeVariables.GetInstance();
                    
        SetupControls();
    }
	
	void Update() 
    {
        if (!isControllable)
            return;
            
        ProcessActions();
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
            playerMovement.MovePlayerUp(playerObj);
        }
        
        if (Input.GetKeyDown(ActionMoveDown))
        {
            playerMovement.MovePlayerDown(playerObj);
        }
        
        if (Input.GetKeyDown(ActionShoot))
        {
            playerShooting.ShootProjectile(playerObj, playerID);
        }
        
        if (Input.GetKeyDown(ActionBuildFirewall))
        {
            playerBuilding.HandleBuild(playerObj, playerID, playerMovement.CurrentLane);
        }
    }
}
