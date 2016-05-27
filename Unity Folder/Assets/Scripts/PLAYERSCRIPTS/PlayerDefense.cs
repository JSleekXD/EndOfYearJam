using UnityEngine;
using System.Collections;

public class PlayerDefense : MonoBehaviour {

	private SceneManager sceneManager;


	public float defenseHealthMax  = 100f;
	public float defenseHealthCurrent = 0f ;
	private float projectileDamage;
	private int playerID;
	private int tempWinID;

//	void Awake(){
//		DontDestroyOnLoad (transform.gameObject);
//	}

	// Use this for initialization
	void Start () {
	
		ResetDefense ();
		sceneManager = GameObject.FindGameObjectWithTag ("SCENEMANAGER").GetComponent<SceneManager>();
		projectileDamage = defenseHealthMax / (sceneManager.DesksCount() * 2);
	//	Debug.Log (projectileDamage);
	}
	
	// Update is called once per frame
	void Update () {
		//print (sceneManager.DesksCount ());
		//Debug.Log (projectileDamage);
	}

	public void ResetDefense(){
		defenseHealthCurrent = defenseHealthMax;
	}

	void OnTriggerEnter2D(Collider2D collider){
	
		Destroy (collider);
		defenseHealthCurrent -= projectileDamage;
		Debug.Log (defenseHealthCurrent);
		if (defenseHealthCurrent <= 0) {
			tempWinID = collider.GetComponent<Projectile>().projectileID;
//			if(collider.GetComponent<Projectile>().projectileID != null){
//				if(collider.GetComponent<Projectile>().projectileID == 1){
//					playerID = 0;
//				}else if(collider.GetComponent<Projectile>().projectileID == 0){
//					playerID = 1;
//				}
//			}
			KillPlayer();
		}
	}

	public void KillPlayer(){
		sceneManager.winnerID = tempWinID;
		Application.LoadLevel ("EndMenu");
	}
}


