using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeskManager : MonoBehaviour 
{
    public int desiredDesks = 4;
    public List<GameObject> desks;
    public GameObject deskRef;

    void Start() 
    {
        GameObject deskParent = GameObject.Find("Desks");
        for (int i = 0; i < desiredDesks; ++i) 
        {
            GameObject newDesk = Instantiate(deskRef);
            newDesk.transform.SetParent(deskParent.transform);
            newDesk.transform.position = new Vector2(0, 0 + (i * 2));
            desks.Add(newDesk);
        }

        deskParent.transform.position = new Vector2(0, 0 - (desiredDesks - 1));
    }
}
