using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleManager : MonoBehaviour 
{
	RuntimeVariables runtimeVariables;

    private Toggle player0Toggle;
    private Toggle player1Toggle;
        
    void Awake()
    {
		runtimeVariables = RuntimeVariables.GetInstance();
		
		player0Toggle = GameObject.Find("Player0Toggle").GetComponent<Toggle>();
		player1Toggle = GameObject.Find("Player1Toggle").GetComponent<Toggle>();
		
		player0Toggle.isOn = runtimeVariables.isPlayer0Toggled;
		player1Toggle.isOn = runtimeVariables.isPlayer1Toggled;
		
		InvokeRepeating("UpdateRuntimeVariables", 0.2f, 0.2f);
    }
    
	void UpdateRuntimeVariables()
	{
    	runtimeVariables.isPlayer0Toggled = player0Toggle.isOn;
		runtimeVariables.isPlayer1Toggled = player1Toggle.isOn;
	}
}
