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
        
        TranslatePlayerY(player, 2f);
        ++currentLane;
    }
    
    public void MovePlayerDown(GameObject player)
    {
        if (currentLane == 0)
            return;
        
        TranslatePlayerY(player, -2f);
        --currentLane;
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
