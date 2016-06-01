using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public GameObject roundOverSound;
	public GameObject virusHitVirusSound;
	public GameObject virusHitFirewallSound;


	public static AudioManager instance;

	public void PlayRoundOverSound(){
		roundOverSound.SetActive (true);
	}
	public void StopRoundOverSound(){
		roundOverSound.SetActive (false);
	}
	public void PlayVirusHitVirusSound(){
		virusHitVirusSound.GetComponent<AudioSource> ().Play ();
	}
	public void PlayVirusHitFirewallSound(){
		virusHitFirewallSound.GetComponent<AudioSource> ().Play ();
	}





}
