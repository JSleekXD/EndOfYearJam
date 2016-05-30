using UnityEngine;
using System.Collections;

public class NPCShoot : MonoBehaviour 
{
	public float projectileSpeed = 0.25f;
	public float offsetFromPlayer = 1.0f;

	// Use this for initialization
	void Start ()
	{
		if (GetComponent<NPCProperties>().npcID == 1) 
		{
			projectileSpeed = -projectileSpeed;
			offsetFromPlayer = -offsetFromPlayer;
		}
	}

	public void ShootingProjectiles(GameObject npcObject, int npcID)
	{
		// RULES:
		//	Select random value
		//	

	}
}
