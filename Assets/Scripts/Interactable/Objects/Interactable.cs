﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal contextOn;
    public Signal contextOff;
    public bool playerInRange;
    public SpriteRenderer item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            contextOn.Raise();
            playerInRange = true;
            item.color = Color.green;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contextOff.Raise();
            playerInRange = false;
            item.color = Color.white;
        }
    }
}
