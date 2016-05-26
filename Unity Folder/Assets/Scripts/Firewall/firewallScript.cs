using UnityEngine;
using System.Collections;

public class firewallScript : MonoBehaviour 
{
    private GameObject projectile;
    
    
    // Use this for initialization
    void Awake () 
    {
        projectile = GameObject.FindGameObjectWithTag("PROJECTILE");     
        gameObject.SetActive(true);
    }
    
    // Update is called once per frame
    void Update () 
    {
        
    }
    
    void OnCollisionEnter2D(Collision other)
    {
        if (other.gameObject == projectile)
        {
            gameObject.SetActive(false);
        }
    }
}
