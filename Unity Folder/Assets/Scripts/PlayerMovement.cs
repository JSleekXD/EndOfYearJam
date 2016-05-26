using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private int currentLane = 0;
    private Transform player;
    public int playerID;
    public GameObject[] deskArray;

	void Start() 
	{
        player = GameObject.Find("Player" + playerID).transform;
        deskArray = GameObject.FindGameObjectsWithTag("DESK");

		if (playerID == 0) {
			transform.position = new Vector2 (deskArray [0].transform.position.x - 5, 0);
		}
		if (playerID == 1){
			transform.position = new Vector2 (deskArray [0].transform.position.x + 5, 0);
		}

	}
	
	void Update() 
	{
        ProcessMovement(playerID);
	}

    public void ProcessMovement(int id)
    {
        string axis = "Vertical" + id;

        if (Input.GetButtonDown(axis) && Input.GetAxisRaw(axis) > 0f)
        {
            if (currentLane == deskArray.Length - 1)
                return;
            
            TranslatePlayerY(2f);
            ++currentLane;
        }
        
        if (Input.GetButtonDown(axis) && Input.GetAxisRaw(axis) < 0f)
        {
            if (currentLane == 0)
                return;
            
            TranslatePlayerY(-2f);
            --currentLane;
        }
    }

    public void TranslatePlayerY(float amount)
    {
        player.position = new Vector3(player.position.x, player.position.y + amount, 0);
    }
}
