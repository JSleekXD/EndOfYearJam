using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private int currentLane = 0;
    private Transform player;
    private int playerID;
    public GameObject[] deskArray;

	void Start() 
	{
		playerID = GetComponent<PlayerProperties> ().playerID;
        player = GameObject.Find("Player" + playerID).transform;
        deskArray = GameObject.FindGameObjectsWithTag("DESK");

		if (playerID == 0) {
			//transform.position = new Vector2 (deskArray [0].transform.position.x - 5, 0);
			transform.position = new Vector2(0 - deskArray[0].transform.localScale.x/2, deskArray[0].transform.position.y);
		}
		if (playerID == 1){
			//transform.position = new Vector2 (deskArray [0].transform.position.x + 5, 0);
			transform.position = new Vector2(0 + deskArray[0].transform.localScale.x/2, deskArray[0].transform.position.y);

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


	public GameObject[] GetDeskArray()
	{
		return deskArray;
	}
}
