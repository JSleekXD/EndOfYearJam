using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour 
{
	public void PlayButton()
    {
        Application.LoadLevel("Joe's Scene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
