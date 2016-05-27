using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleManager : MonoBehaviour {

    public bool isPlayer1Toggled = false;
    public bool isPlayer2Toggled = false;
    
    private Toggle player1Toggle;
    private Toggle player2Toggle;
	
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        
        player1Toggle = GameObject.Find("Player1Toggle").GetComponent<Toggle>();
        player2Toggle = GameObject.Find("Player2Toggle").GetComponent<Toggle>();
    }
    
	void Update() 
    {
        if (Application.loadedLevel != 0)
            return;
            
        isPlayer1Toggled = player1Toggle.isOn;
        isPlayer2Toggled = player2Toggle.isOn;
	}
}
