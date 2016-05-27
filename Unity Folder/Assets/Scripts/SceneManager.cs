using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour 
{
    public int desiredDesks = 4;
	public int p1totalFirewalls;
	public int p2totalFirewalls;
    public List<GameObject> desks;
    public GameObject deskRef;
    public GameObject defenseTriggerRef;
	public int winnerID;
	public GameObject winText;
	private bool isGameOver =false;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);

		p1totalFirewalls = 0;
		p2totalFirewalls = 0;
	}

    void Start() 
    {
        SpawnDesks();
        ZoomCamera();
        SpawnDefenseTriggers();
		Debug.Log ("START");
    }
	void Update(){
		CheckIfEndScene ();
	}
	void CheckIfEndScene(){
		if (!isGameOver) {
			if (Application.loadedLevel == 3) {
				winText = GameObject.FindGameObjectWithTag ("WINTEXT");
				winText.GetComponent<Text>().text = "PLAYER " + (winnerID+1) + " WINS!";
				isGameOver = true;
			}
		}
	}
    
    void SpawnDesks()
    {
        GameObject deskParent = GameObject.Find("Desks");
        for (int i = 0; i < desiredDesks; ++i) 
        {
            GameObject newDesk = Instantiate(deskRef);
            newDesk.name = "Desk" + i;
            
            newDesk.transform.SetParent(deskParent.transform);
            newDesk.transform.position = new Vector2(0, 0 + (i * 2));
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
        for (int i = 0; i < 2; ++i)
        {
            GameObject newDefenseTrigger = Instantiate(defenseTriggerRef);
            newDefenseTrigger.name = "Player" + i + "Defense";
            
            float offset = -((deskLength / 2) + 1f);
            if (i == 1) offset = -offset;
            newDefenseTrigger.transform.position = new Vector2(offset, 0);
            
            newDefenseTrigger.transform.localScale = new Vector2(1, desiredDesks * 2);
        }
    }

	public int DesksCount()
	{
		return desks.Count;
	}
}
