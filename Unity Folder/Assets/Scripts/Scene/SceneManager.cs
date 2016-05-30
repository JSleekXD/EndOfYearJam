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

    void Start()
    {
		runtimeVariables = RuntimeVariables.GetInstance ();

        SpawnDesks();
        ZoomCamera();
        SpawnDefenseTriggers();
		SpawnNPC ();
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
		}
		if (newPlayer.GetComponent<PlayerProperties> ().playerID == 1) {
			newPlayer.transform.localEulerAngles = new Vector3(0,0,180);
		}
	}

	void SpawnNPC()
	{
		// Check if the player has selected single player mode. 
		if (runtimeVariables.isSinglePlayerToggled) {
			numberOfPlayers = 1;
		} else {
			numberOfPlayers = 2;
		}

		float offsetX = desks [0].transform.localScale.x / 2;

		newNPC = Instantiate (nonPlayerCharacterRef);
		newNPC.name = "Non-Player Character";

		newNPC.transform.position = new Vector2 (0 + offsetX, desks [0].transform.position.y);
		newNPC.GetComponent<NPCProperties> ().npcID = 1;											// This could be changed when the side the NPC is on. 
		players.Add (newNPC);
	}
	
	public int DesksCount
	{
		get { return desks.Count; }
	}
    
    public void EnablePlayerControl(bool value)
	{
        foreach (GameObject p in players)
        {
			if(p == newPlayer)
				p.GetComponent<PlayerControl>().isControllable = value;

			Debug.Log (p);


			if(p == newNPC)
				newNPC.GetComponent<NPCControl>().isControllable = value;

			Debug.Log (p);
        }
    }
    
    public void EndOfRound()
    {
    	DetermineRoundWinner();

    }
    
    void DetermineRoundWinner()
    {
		int tempWinnerID = 10;
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
		
		print("Player" + (tempWinnerID + 1) + " wins the round!");
    }
}
