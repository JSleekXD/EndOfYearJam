using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour 
{
    public List<GameObject> players;
    public GameObject playerRef;

	public GameObject nonPlayerCharacterRef;

	private GameObject newNPC = null;
	private GameObject newPlayer = null;

	private int numberOfPlayers = 2;
    
    public GameObject defenseTriggerRef;
    public List<GameObject> defenseTriggers;
    
	public int desiredDesks = 4;
	public List<GameObject> desks;
	public GameObject deskRef;

    private bool controlEnabled;
    private float BASE_DEFENSE_TRIGGER_OFFSET_X = 3f;
	private RuntimeVariables runtimeVariables;

	public GameObject computerRef;
	public List<GameObject> leftComputers;
	public List<GameObject> rightComputers;
	
	public GameObject stationRef;

	public GameObject roundOverText;

    void Start()
    {
		runtimeVariables = RuntimeVariables.GetInstance ();
		runtimeVariables.player0RoundsWon = 0;
		runtimeVariables.player1RoundsWon = 0;
		
		// Check if the player has selected single player mode. 
		if (runtimeVariables.isSinglePlayerToggled) 
		{
			numberOfPlayers = 1;
		} else {
			numberOfPlayers = 2;
		}

        SpawnDesks();
		SpawnComputers();
        ZoomCamera();
        SpawnDefenseTriggers();
        SpawnPlayers();  
    }
    
	void SpawnDesks()
	{
		GameObject deskParent = GameObject.Find("Desks");
		for (int i = 0; i < desiredDesks; ++i) 
		{
			GameObject newDesk = Instantiate(deskRef);
			newDesk.name = "Desk" + i;
			
			newDesk.transform.SetParent(deskParent.transform);
			newDesk.transform.position = new Vector2(0, deskParent.transform.position.y + (i * 2));
			desks.Add(newDesk);
		}
		
		deskParent.transform.position = new Vector2(0, 0 - (desiredDesks - 1));
	}

	void SpawnComputers()
	{
		GameObject computerParent = GameObject.Find("Computers");
		GameObject stationParent = GameObject.Find("Stations");
		
		for (int i = 0; i < desiredDesks; i++) 
		{
			SpawnComputer(computerParent, stationParent, i, leftComputers, 270);
		}
		
		for (int i = 0; i < desiredDesks; i++) 
		{
			SpawnComputer(computerParent, stationParent, i, rightComputers, 90);
		}
	}
	
	void SpawnComputer(GameObject computerParent, GameObject stationParent, int i, List<GameObject> list, float rotationZ)
	{
		GameObject newComputer = Instantiate(computerRef);
		newComputer.name = "Computer" + i;
		newComputer.transform.SetParent(computerParent.transform);
		newComputer.transform.localEulerAngles = new Vector3(0, 0, rotationZ);
		newComputer.transform.Find("ComputerScreenFirewall").transform.GetComponent<Image>().fillAmount = 0;
		list.Add(newComputer);
		
		int tempSide = 0;
		float tempOffsetX = -((desks[0].transform.localScale.x / 2) - 1.9f);
		if (list == leftComputers)
		{
			tempSide = 0;
		}
		else
		{
			tempSide = 1;
			tempOffsetX = -tempOffsetX;
		}
		
		newComputer.transform.position = new Vector2(tempOffsetX, desks[i].transform.position.y);
		SpawnStation(stationParent, newComputer.transform, tempSide, rotationZ);
	}
	
	void SpawnStation(GameObject stationParent, Transform newComputer, int side, float rotationZ)
	{
		GameObject newStation = Instantiate(stationRef);
		newStation.name = "Station";
		newStation.transform.SetParent(stationParent.transform);
		newStation.transform.localEulerAngles = new Vector3(0, 0, rotationZ);
		
		float tempOffsetX = 1.9f;
		if (side == 1)
			tempOffsetX = -tempOffsetX;
			
		newStation.transform.position = new Vector2(newComputer.position.x - tempOffsetX, newComputer.position.y);
	}
	
	void ZoomCamera()
	{
		Camera cameraRef = GameObject.Find("Main Camera").GetComponent<Camera>();
		if (desiredDesks > 4)
			cameraRef.orthographicSize = desiredDesks;
	}
	
	void SpawnDefenseTriggers()
	{
		float deskLength = desks[0].transform.localScale.x;
        float offsetX = -((deskLength / 2) + BASE_DEFENSE_TRIGGER_OFFSET_X);
        
		for (int i = 0; i < 2; ++i)
		{
			GameObject newDefenseTrigger = Instantiate(defenseTriggerRef);
			newDefenseTrigger.name = "Player" + i + "Defense";
			
			if (i == 1) 
                offsetX = -offsetX;
                
			newDefenseTrigger.transform.position = new Vector2(offsetX, 0);
			newDefenseTrigger.transform.localScale = new Vector2(1, desiredDesks * 2);
            defenseTriggers.Add(newDefenseTrigger);
		}
	}

	void SpawnPlayers()
	{
		float offsetX = -(desks[0].transform.localScale.x / 2);
		
		for (int i = 0; i < numberOfPlayers; ++i)
		{
            newPlayer = Instantiate(playerRef);
            newPlayer.name = "Player" + i;
            
            if (i == 1)
                offsetX = -offsetX;
                
			newPlayer.transform.position = new Vector2 (0 + offsetX, desks[0].transform.position.y);
            newPlayer.GetComponent<PlayerProperties>().playerID = i;
            players.Add(newPlayer);

			if (numberOfPlayers == 1)
			{
				offsetX = -offsetX;
				SpawnNPC(offsetX);
			}
		}

		if (newPlayer.GetComponent<PlayerProperties>().playerID == 1) 
		{
			newPlayer.transform.localEulerAngles = new Vector3(0,0,180);
		}
	}

	void SpawnNPC(float offSetX)
	{
		newNPC = Instantiate (nonPlayerCharacterRef);
		newNPC.name = "Player1";

		newNPC.transform.position = new Vector2 (0 + offSetX, desks [0].transform.position.y);
		newNPC.GetComponent<PlayerProperties> ().playerID = 1;
		newNPC.transform.localEulerAngles = new Vector3(0,0,180);

		players.Add(newNPC);
	}
	
	public int DesksCount
	{
		get { return desks.Count; }
	}
    
    public void EnablePlayerControl(bool value)
	{
        foreach (GameObject p in players)
        {
			if (p.gameObject.tag == "Player")
				p.GetComponent<PlayerControl>().isControllable = value;
				
			if (p.gameObject.tag == "NPC")
				newNPC.GetComponent<NPCControl>().isControllable = value;
        }
    }
	
    public void EndOfRound()
    {
		roundOverText.GetComponent<Text> ().text = "ROUND OVER";
		DetermineRoundWinner();

		ResetComputerScreens ();
		ResetPlayerPositions();
    	RemoveAllFirewalls();
    	RemoveAllProjectiles();
    	ResetDefense();
		//wait for 2 seconds
		StartCoroutine(WaitAfterRoundFinished(2.0f));
    	
    }

	private IEnumerator WaitAfterRoundFinished(float time){
		//stop the background music
		//play the round end music
		roundOverText.SetActive (true);
		EnablePlayerControl (false);
		yield return new WaitForSeconds (time);
		DetermineGameOver();
		//disable round over text
		roundOverText.SetActive (false);
		ResetCountdown();
	}
    
    void DetermineRoundWinner()
    {
		int tempWinnerID = 0;
		float healthComparison = 0f;
		for (int i = 0; i < 2; ++i)
		{
			PlayerDefense defenseRef = defenseTriggers[i].GetComponent<PlayerDefense>();
			if (defenseRef.defenseHealthCurrent > healthComparison)
			{
				healthComparison = defenseRef.defenseHealthCurrent;
				tempWinnerID = i;
			}
		}
		PlayerDefense player0DefenseRef = defenseTriggers [0].GetComponent<PlayerDefense> ();
		PlayerDefense player1DefenseRef = defenseTriggers [1].GetComponent<PlayerDefense> ();

		if (player0DefenseRef.defenseHealthCurrent == player1DefenseRef.defenseHealthCurrent) {
			roundOverText.GetComponent<Text>().text = "TIE!";
			return;
		}
		
		GameObject.Find("Player" + tempWinnerID + "WinCounter").GetComponent<Image>().enabled = true;	
		
		if (tempWinnerID == 0)
			++runtimeVariables.player0RoundsWon;
		
		if (tempWinnerID == 1)
			++runtimeVariables.player1RoundsWon;
    }
    
    void DetermineGameOver()
    {
    	if (runtimeVariables.player0RoundsWon == 2 || runtimeVariables.player1RoundsWon == 2)
			Application.LoadLevel("EndScene");
    }
    
    void ResetPlayerPositions()
    {
		float offsetX = -(desks[0].transform.localScale.x / 2);
		for (int i = 0; i < 2; ++i)
		{
			if (i == 1)
				offsetX = -offsetX;
				
			players[i].GetComponent<PlayerMovement>().MoveToLane(0);
		}
    }
    
    void RemoveAllProjectiles()
    {
		foreach (GameObject player in players)
		{
			player.GetComponent<PlayerShooting>().RemoveAllProjectiles();
		}
    }
    
    void RemoveAllFirewalls()
    {
    	foreach (GameObject player in players)
    	{
    		player.GetComponent<PlayerBuilding>().RemoveAllFirewalls();
    	}
    }

	void ResetComputerScreens(){
		for (int i = 0; i < leftComputers.Count; i++) {
			leftComputers[i].transform.Find("ComputerScreenFirewall").transform.GetComponent<Image>().fillAmount = 0;
		}
		for (int i = 0; i < rightComputers.Count; i++) {
			rightComputers[i].transform.Find("ComputerScreenFirewall").transform.GetComponent<Image>().fillAmount = 0;
		}
	}
    
    void ResetDefense()
    {
    	foreach (GameObject trigger in defenseTriggers)
    	{
    		trigger.GetComponent<PlayerDefense>().Reset();
    	}
    }
    
    void ResetCountdown()
    {
    	GameObject.Find("CountdownManager").GetComponent<CountdownManager>().Reset();
    }
}


