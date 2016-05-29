using UnityEngine;
using System.Collections;

public class StartSceneActions : MonoBehaviour 
{
    public void PlayButton()
    {
        Application.LoadLevel("GameScene");
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
