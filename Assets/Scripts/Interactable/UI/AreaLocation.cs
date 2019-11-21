using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLocation : MonoBehaviour
{
    public string areaName;
    public Area playerLocation;
    public bool playerOn;
    public Signal areaSignal;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOn = true;
            playerLocation.Name = areaName;
            playerLocation.isPlayer = true;
            areaSignal.Raise();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            areaSignal.Raise();
        }
    }
}
