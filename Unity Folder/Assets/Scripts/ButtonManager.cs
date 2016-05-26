using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour 
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
