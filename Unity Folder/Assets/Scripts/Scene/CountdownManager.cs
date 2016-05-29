using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownManager : MonoBehaviour 
{
    private Text countdownText;
    private AudioSource source;
    public AudioClip beep;
    public AudioClip beepEnd;
    
    public float countdownFrom = 3f;
    private float currentTime = 0f;
    
    private SceneManager sceneManager;
    
	void Start() 
    {
	    countdownText = GameObject.Find("CountdownText").GetComponent<Text>();
        source = GetComponent<AudioSource>();
        
        currentTime = countdownFrom;
        StartCoroutine(Countdown(currentTime));
	}
	
	void Update() 
    {
        UpdateText();
	}
    
    void UpdateText()
    {
        countdownText.text = currentTime.ToString();
        countdownText.color = currentTime <= 5.0f && Mathf.Floor(currentTime) % 2 != 0 ? Color.red : Color.black;
    }
    
    private IEnumerator Countdown(float _time)
    {
        yield return new WaitForSeconds(1.0f);
        
        if (_time <= 0)
        {
            source.PlayOneShot(beepEnd);
            countdownText.color = Color.white;
            
            GameObject.Find("SceneManager").GetComponent<SceneManager>().EnablePlayerControl();
            
            Destroy(gameObject, 1f);
            Destroy(countdownText.gameObject, 1f);
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
