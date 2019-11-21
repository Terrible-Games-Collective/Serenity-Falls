using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal contextOn;
    public Signal contextOff;
    public bool playerInRange;
    public SpriteRenderer item;
    
    // This handles the triggers when the player goes near an interactable
    // enable and disables UI -< E button >- 
    // also change the color

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            contextOn.Raise();
            playerInRange = true;
            if (item.color != Color.red)
            {
                item.color = Color.green;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contextOff.Raise();
            playerInRange = false;
            if (item.color != Color.red)
            {
                item.color = Color.white;
            }
            
        }
    }
}
