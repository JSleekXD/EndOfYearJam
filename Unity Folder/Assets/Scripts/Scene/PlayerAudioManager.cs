using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour {

	public GameObject firewallBuildingSound;

	public void PlayFirewallBuildingSound(){

		firewallBuildingSound.GetComponent<AudioSource> ().volume = 1;
	}
	public void StopFirewallBuildingSound(){
		firewallBuildingSound.GetComponent<AudioSource> ().volume = 0;
	}
}
