using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal contextOn;
    public Signal contextOff;
    public bool playerInRange;
    public SpriteRenderer item;
    public GameObject lightUIG;
    public GameObject lightUIR;

    // for item status UI
    public bool usable = true;

    // monster door interaction
    public bool enemyInrange;

    // This handles the triggers when the player goes near an interactable object
    // enable and disables UI
    // also highlights the object


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            contextOn.Raise();
            playerInRange = true;
            // if item can be used glow green
            if (usable)
            {
                item.color = Color.green;
                lightUIG.SetActive(true);
            }
            // if not usable glow red
            if (!usable)
            {
                item.color = Color.red;
                lightUIR.SetActive(true);
            }
            
        }
        if (collision.CompareTag("Monster") || collision.CompareTag("Nurse"))
        {
            enemyInrange = true;
        }

    }
    // turn off glow if player not in range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contextOff.Raise();
            playerInRange = false;
            if (usable)
            {
                item.color = Color.white;
                lightUIG.SetActive(false);
            }
            


        }
        if (collision.CompareTag("Monster") || collision.CompareTag("Nurse"))
        {
            enemyInrange = false;
        }
    }
}
