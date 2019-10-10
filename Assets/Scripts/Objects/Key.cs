﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public Inventory playerInventory;
    public SpriteRenderer keySprite;
    public BoxCollider2D triggerCollider;
    public CircleCollider2D keyCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            GetKey();
        }
    }
    public void GetKey()
    {
        playerInventory.Key = true;
        keySprite.enabled = false;
        triggerCollider.enabled = false;
        keyCollider.enabled = false;
    }
}