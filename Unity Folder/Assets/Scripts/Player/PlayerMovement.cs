using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public GameObject nonPlayerCharacter;

	private int currentLane = 0;
    private int numDesks;		

    void Start()
    {
        numDesks = GameObject.Find("SceneManager").GetComponent<SceneManager>().DesksCount;
    }
    
    public void MovePlayerUp(GameObject player)
    {
        if (currentLane == numDesks - 1)
            return;
        
        TranslatePlayerY(player, 2f);
        ++currentLane;

		AddLaneToList (currentLane);
    }
    
    public void MovePlayerDown(GameObject player)
    {
        if (currentLane == 0)
            return;
        
        TranslatePlayerY(player, -2f);
        --currentLane;

		AddLaneToList (currentLane);
    }

	private void AddLaneToList(int lane)
	{
		if (nonPlayerCharacter != null) {
			nonPlayerCharacter.GetComponent<NPCMovement> ().targetLanes.Add (lane);
			Debug.Log("LaneADDED");
		}
	}

	private void TranslatePlayerY(GameObject player, float amount)
	{
		player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + amount, 0);
	}

	public int CurrentLane
	{
		get { return currentLane; }
	}
}
