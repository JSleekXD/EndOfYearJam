using UnityEngine;
using System.Collections;

public class PlayerDefense : MonoBehaviour 
{
	public float defenseHealthMax = 100f;
	public float defenseHealthCurrent;
	private SceneManager sceneManager;
	private float projectileDamage = 0f;

	void Start() 
	{
		Reset();
	}

	void Reset()
	{
		sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
		projectileDamage = defenseHealthMax / (sceneManager.DesksCount * 2);
		defenseHealthCurrent = defenseHealthMax;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag != "Projectile")
			return;

		int projectileID = other.gameObject.GetComponent<Projectile>().PlayerID;
		GameObject.Find("Player" + projectileID).GetComponent<PlayerShooting>().RemoveProjectile(other.gameObject);
		
		defenseHealthCurrent -= projectileDamage;
		if (defenseHealthCurrent <= 0)
		{
            RuntimeVariables.GetInstance().lastPlayerToWin = projectileID;
            Application.LoadLevel("EndScene");
		}
	}
}
