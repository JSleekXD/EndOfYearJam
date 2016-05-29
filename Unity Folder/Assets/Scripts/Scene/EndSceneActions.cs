using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndSceneActions : MonoBehaviour 
{
	void Start()
	{
		GameObject.Find("WinText").GetComponent<Text>().text = "Player " + (RuntimeVariables.GetInstance().lastPlayerToWin + 1) + " Wins!";
	}
	
    public void RestartButton()
    {
        Application.LoadLevel("StartScene");
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
