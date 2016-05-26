using UnityEngine;
using System.Collections;

public class EndMenuManager : MonoBehaviour 
{
	public void RestartButton()
    {
        Application.LoadLevel("Julian's Scene");
    }

    public void MainMenuButton()
    {
        Application.LoadLevel("MainMenu");
    }
}
