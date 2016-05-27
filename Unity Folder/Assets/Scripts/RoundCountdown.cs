using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundCountdown : MonoBehaviour {

	public Text countDownText;
	public AudioSource countDownBeep, startBeep;
	public float time = 0f;
	public bool countFinished = false;

	// Use this for initialization
	void Awake(){
		countDownText.text = "0";
	}
	void Start () {
		countDownBeep = GameObject.FindGameObjectWithTag("BEEP").GetComponent<AudioSource>();
		startBeep = GameObject.FindGameObjectWithTag("BEEPEND").GetComponent<AudioSource>();

		CountDown (3f);

	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
	}

	public void UpdateText()
	{
		// Debug.Log("GETTINGCALLEd");
		countDownText.text = time.ToString();
		countDownText.color = time <= 5.0f && Mathf.Floor(time) % 2 != 0 ? Color.red : Color.black;//flash text red?
	}

	public void CountDown(float _time/* bool _sound = true*/)
	{
		countFinished = false;
		//m_sound = _sound;
		time = _time;
		//init count down
		StartCoroutine(ICountDown(_time));
	}


	private IEnumerator ICountDown(float _time)
	{
		//timer
		yield return new WaitForSeconds(1.0f);
		if (_time <= 0)//check for end
		{
			 startBeep.Play();/*SoundManager.instance.PlayClip(startBeep);*/ //play final beep
//			if (m_callback != null)//if callback set
//			{
//				m_callback();//launch callback
//			}
			countFinished = true;//set fin flag
			countDownText.color = Color.white;
		}
		else if (_time <= 5.0f)//last 5 secs? play beep
		{
			 { countDownBeep.Play();/*SoundManager.instance.PlayClip(countDownBeep); */}
		}
		if (_time > 0) { --_time; time = _time; StartCoroutine(ICountDown(time)); }//recursive count down
		
	}
}
