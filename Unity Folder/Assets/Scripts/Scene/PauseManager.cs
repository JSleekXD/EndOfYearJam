using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour 
{
	public GameObject pauseText;
	public bool paused = false;

	void Start() 
	{
		
	}
	

	void Update() 
	{
		if (Input.GetKeyDown("escape"))
		{
			if (paused == true)
			{
				Time.timeScale = 1.0f;
				pauseText.SetActive(false);
				paused = false;
			}
			else
			{
				Time.timeScale = 0.0f;
				pauseText.SetActive(true);
				paused = true;
			}
		}
	}
}
