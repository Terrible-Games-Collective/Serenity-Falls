using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : Interactable
{
    public GameObject[] lights;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            UseBreaker();
        }
    }
    public void UseBreaker()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            Debug.Log("Power are now on/off");
        }
    }

}
