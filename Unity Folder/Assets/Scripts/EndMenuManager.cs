using UnityEngine;
using System.Collections;

public class EndMenuManager : MonoBehaviour 
{
	public void QuitButton()
    {
		Application.Quit ();
    }

    public void MainMenuButton()
    {
        Application.LoadLevel("MainMenu");
    }
}
