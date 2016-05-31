using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public GameObject roundOverSound;

	public static AudioManager instance;

	public void PlayRoundOverSound(){
	//	roundOverSound.enabled = true;
		roundOverSound.SetActive (true);
	}
	public void StopRoundOverSound(){
		roundOverSound.SetActive (false);
	}


}
