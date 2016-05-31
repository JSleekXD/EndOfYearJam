using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour 
{
	public GameObject projectile;
	public List<GameObject> projectiles;
    public float projectileSpeed = 0.25f;
    public float offsetFromPlayer = 1f;

	private Quaternion playerOneSpawnRot = new Quaternion(180.0f, 180.0f, 0.0f, 0.0f);
	private Quaternion playerTwoSpawnRot = new Quaternion(217.0f, -217.0f, 0.0f, 0.0f);
	public float newScaleX = 2.0f;
	public float newScaleY = 2.0f;
    
    void Start()
    {
        if (GetComponent<PlayerProperties>().playerID == 1) 
        {
            projectileSpeed = -projectileSpeed;
            offsetFromPlayer = -offsetFromPlayer;
        }
    }
	
	public void ShootProjectile(GameObject player, int playerID)
	{
        if (projectiles.Count >= 3)
            return;

		// Depending on the playerID change the rotation of the projectile
		gameObject.GetComponent<PlayerControl> ().audioManager.PlayShootVirusSound ();
        GameObject projectileInstance = (GameObject)Instantiate(projectile, new Vector3(player.transform.position.x + offsetFromPlayer, player.transform.position.y, player.transform.position.z), player.transform.rotation);
		projectileInstance.transform.localScale = new Vector2 (newScaleX, newScaleY);
		projectileInstance.name = "Player" + playerID + "Projectile";
        projectileInstance.GetComponent<Projectile>().SetProperties(playerID, projectileSpeed, player.GetComponent<PlayerMovement>().CurrentLane);

		if (playerID == 0)
			projectileInstance.transform.rotation = playerOneSpawnRot;
		if(playerID == 1)
			projectileInstance.transform.rotation = playerTwoSpawnRot;

		projectiles.Add(projectileInstance);
	}

	public void RemoveProjectile(GameObject projectile)
	{
		projectiles.Remove(projectile);
		Destroy(projectile);
	}
	
	public void RemoveAllProjectiles()
	{
		foreach (GameObject projectile in projectiles)
		{
			Destroy(projectile);
		}
		
		projectiles.Clear();
	}
}
