using UnityEngine;
using System.Collections;

public class firewallScript : MonoBehaviour 
{
    private GameObject projectile;
    
    
    // Use this for initialization
    void Awake () 
    {
        projectile = GameObject.FindGameObjectWithTag("Projectile");     
        gameObject.SetActive(true);
    }
    
    // Update is called once per frame
    void Update () 
    {
        
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == projectile)
        {
            gameObject.SetActive(false);
        }
    }
}
