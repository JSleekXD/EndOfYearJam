using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleManager : MonoBehaviour 
{
	RuntimeVariables runtimeVariables;

    private Toggle player0Toggle;
    private Toggle player1Toggle;
	private Toggle singlePlayerToggle;
        
    void Awake()
    {
		runtimeVariables = RuntimeVariables.GetInstance();
		
		player0Toggle = GameObject.Find("Player0Toggle").GetComponent<Toggle>();
		player1Toggle = GameObject.Find("Player1Toggle").GetComponent<Toggle>();
		singlePlayerToggle 	= GameObject.Find ("SinglePlayerToggle").GetComponent<Toggle> ();				// NEW

		player0Toggle.isOn = runtimeVariables.isPlayer0Toggled;
		player1Toggle.isOn = runtimeVariables.isPlayer1Toggled;
		singlePlayerToggle.isOn = runtimeVariables.isSinglePlayerToggled;
		
		InvokeRepeating ("UpdateRuntimeVariables", 0.2f, 0.2f);
    }
    
	void UpdateRuntimeVariables()
	{
    	runtimeVariables.isPlayer0Toggled = player0Toggle.isOn;
		runtimeVariables.isPlayer1Toggled = player1Toggle.isOn;
		runtimeVariables.isSinglePlayerToggled = singlePlayerToggle.isOn;
	}
}
