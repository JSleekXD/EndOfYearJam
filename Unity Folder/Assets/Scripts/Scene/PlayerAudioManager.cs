﻿using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour {

	public GameObject firewallBuildingSound;
	public GameObject firewallPlacedSound;

	public void PlayFirewallBuildingSound(){

		firewallBuildingSound.GetComponent<AudioSource> ().volume = 1;
	}
	public void StopFirewallBuildingSound(){
		firewallBuildingSound.GetComponent<AudioSource> ().volume = 0;
	}


	public void PlayFirewallPlacedSound(){
		firewallPlacedSound.GetComponent<AudioSource> ().Play ();
	}
}
