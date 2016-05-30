using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour
{
	private int currentLane = 0;
	private int numDesks;
	public float timer;
	public const float MAX_TIME = 3.0f; 

	public int targetLane;
	public int amountMoves;
	public bool isMoving;
	public bool isWaiting;
	public bool isNeg;
	public bool isPos;


	void Start()
	{
		numDesks = GameObject.Find ("SceneManager").GetComponent<SceneManager> ().DesksCount;
		isMoving = false;
	}

	public void Movement(GameObject npcObject)
	{
		if (!isMoving) {
			targetLane = GenerateRandomNum ();			// Generate a random number
			amountMoves = targetLane - currentLane;		// Get the number of moves to make

			// Get the direction to move in. 
			if (amountMoves < 0) {
				isNeg = true;
				isPos = false;
			} else {
				isPos = true;
				isNeg = false;
			}
		}

		// When the NPC reaches the destination. 
		if (targetLane == currentLane) {
			isMoving = false;
			isWaiting = true;
			return;
		} else {
			isMoving = true;
		}

		// Exectuce movement
		if (isNeg)
			NegitiveDirection (npcObject);
		if (isPos) 
			PositiveDirection (npcObject);
	}



	void NegitiveDirection(GameObject npcObject)
	{
		if (!Waiting ()) {
			TranslateNPCY (npcObject, -2f);
			--currentLane;
		}
	}

	void PositiveDirection(GameObject npcObject)
	{
		if (!Waiting ()) {
			TranslateNPCY (npcObject, 2f);
			++currentLane;
		}
	}


	int GenerateRandomNum()
	{
		int randNum = Random.Range (0, numDesks); 
		return randNum;
	}

	
	void TranslateNPCY(GameObject npcObject, float amount)
	{
		npcObject.transform.position = new Vector2(npcObject.transform.position.x, npcObject.transform.position.y + amount);
	}

	bool Waiting()
	{
		if (timer <= MAX_TIME) {
			timer += Time.deltaTime;
			return true;
		}
		timer = 0.0f;
		return false;
	}
}
