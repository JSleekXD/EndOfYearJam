using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour 
{
	public int currentLane = 0;
	private Transform NPCPlayer;
	private int playerID;
	public GameObject[] deskArray;
	
	public AudioSource audioSource;
	public AudioClip beep;
	
	public GameObject roundCountdown;
	public bool playerDisabled = false;

	public int randNum;
	public int targetPos;
	public int numOfMoves;
	public bool start = false;
	public bool waiting = true;
	public float timer = 0;
	public float maxTime = 0.75f;
	//public int targetPos = 0;

	void Start() 
	{
		//roundCountdown = GameObject.FindGameObjectWithTag ("COUNTDOWN");
		audioSource = GetComponent<AudioSource> ();
		playerID = GetComponent<PlayerProperties> ().playerID;
		NPCPlayer = GameObject.FindGameObjectWithTag("NPC").transform;
		deskArray = GameObject.FindGameObjectsWithTag("DESK");
		
		if (playerID == 0) 
		{
			//transform.position = new Vector2 (deskArray [0].transform.position.x - 5, 0);
			transform.position = new Vector2 (0 - deskArray[0].transform.localScale.x/2, deskArray[0].transform.position.y);
			
			//transform.position = new Vector2 (0 - deskArray[0].transform.localScale.x/2, deskArray[deskArray.Length-1].transform.position.y);
		}
		if (playerID == 1)
		{
			//transform.position = new Vector2 (0 + deskArray[0].transform.localScale.x/2, deskArray[deskArray.Length-1].transform.position.y);
			transform.position = new Vector2 (0 + deskArray[0].transform.localScale.x/2, deskArray[0].transform.position.y);
			
			//transform.position = new Vector2 (deskArray [0].transform.position.x + 5, 0);
		}
	}
	
	void Update() 
	{
		//if (roundCountdown.GetComponent<RoundCountdown> ().countFinished)
		//{

		if (start) {
			targetPos = GenerateRandomNum ();
			numOfMoves = currentLane - targetPos;
			// UNTIL REACHED TARGET POSITION
			for (int i =0; i < numOfMoves; i++) {

				Debug.Log ("IN FOR LOOP");
				// DETERMINE WHETHER TO MOVE UP OR DOWN
				if (targetPos > currentLane) {
					Debug.Log ("+ move");
					// POSITIVE MOVE
					ProcessMovement (playerID, true);
				}
				if (targetPos < currentLane) {

					Debug.Log ("- move");
					// NEGITIVE MOVE
					ProcessMovement (playerID, false);
				}

				// WAITING
			//	while (waiting) {
			//		if (timer <= maxTime) {
			//			timer += Time.deltaTime;
			//		} else {
			//		break;
			//		}
				}
			}
		}

		// playerDisabled = false;
		//} 
		//else 
		//{
		//	playerDisabled = true;
		//}


	int GenerateRandomNum()
	{
		randNum = Random.Range (0, deskArray.Length);
		return randNum;
	}


	public void ProcessMovement(int id, bool dir)
	{
	//	if (currentLane == 0)
	//		return;
			switch(dir)
		{
		case true:
			TranslatePlayerY(2f);
			++currentLane;
			
			
			// PLAY AUDIO
			audioSource.PlayOneShot(beep);
			break;
	
		//if (currentLane == deskArray.Length - 1)
		//	return;

		case false:
			TranslatePlayerY(-2f);
			--currentLane;
			
			
			// PLAY AUDIO
			audioSource.PlayOneShot(beep);	

			break;
		}

	}
	
	public void TranslatePlayerY(float amount)
	{
		NPCPlayer.position = new Vector3(NPCPlayer.position.x, NPCPlayer.position.y + amount, 0);
	}
}
