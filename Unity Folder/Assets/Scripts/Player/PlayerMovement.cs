using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
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
        
        TranslatePlayerY(2f);
        ++currentLane;
    }
    
    public void MovePlayerDown(GameObject player)
    {
        if (currentLane == 0)
            return;
        
        TranslatePlayerY(-2f);
        --currentLane;
    }

	private void TranslatePlayerY(float amount)
	{
		gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + amount);
	}
	
	public int CurrentLane
	{
		get { return currentLane; }
	}
	
	public void MoveToLane(int lane)
	{
		float amountToMove = (currentLane + lane) * 2;
		if (lane < currentLane)
			amountToMove = -amountToMove;
		
		currentLane = lane;
		TranslatePlayerY(amountToMove);
	}
}
