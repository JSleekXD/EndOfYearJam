using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownManager : MonoBehaviour 
{
	private SceneManager sceneManager;
    private Text countdownText;
    private AudioSource source;
    public AudioClip beep;
    public AudioClip beepEnd;
    private bool isCountdownFinished = false;
    private bool isRoundFinished = false;
    
    public float countdownFrom = 3f;
    private float currentTime = 0f;
    
    public float roundTime = 60f;
    private float timer;
        
	void Start() 
    {
    	sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
	    countdownText = GameObject.Find("CountdownText").GetComponent<Text>();
        source = GetComponent<AudioSource>();
        
        currentTime = countdownFrom;
        StartCoroutine(Countdown(currentTime));
        
        timer = roundTime;
	}
	
	void Update() 
    {
    	if (isRoundFinished)
    		return;
    		
    	if (!isCountdownFinished)
    	{
        	UpdateCountdownText();
        	return;
        }
        
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		} else {
			isRoundFinished = true;
			sceneManager.EndOfRound();
		}
			
    	UpdateRoundText();
	}
    
    void UpdateCountdownText()
    {
        countdownText.text = currentTime.ToString();
        countdownText.color = currentTime <= 5.0f && Mathf.Floor(currentTime) % 2 != 0 ? Color.red : Color.black;
    }
    
    void UpdateRoundText()
    {
		countdownText.text = Mathf.Round(timer).ToString();
		countdownText.color = Color.red;
    }
    
    private IEnumerator Countdown(float _time)
    {
        yield return new WaitForSeconds(1.0f);
        
        if (_time <= 0)
        {
            source.PlayOneShot(beepEnd);
            countdownText.color = Color.white;
            
            GameObject.Find("SceneManager").GetComponent<SceneManager>().EnablePlayerControl(true);
            
            isCountdownFinished = true;
        }
        else if (_time <= 5.0f)
        {
            source.PlayOneShot(beep);
        }
        
        if (_time > 0) 
        {
            --_time; 
            currentTime = _time; 
            StartCoroutine(Countdown(currentTime));
        }
    }
}
