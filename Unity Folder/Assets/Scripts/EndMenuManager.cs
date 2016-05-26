using UnityEngine;
using System.Collections;

public class EndMenuManager : MonoBehaviour 
{
	public void RestartButton()
    {
        Application.LoadLevel("Joe's Scene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
