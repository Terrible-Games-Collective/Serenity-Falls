using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    normal,
    blocked,
    locked
}
public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool isOpen;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public Signal KeySignal;

    // blocked door
    public float cooldown;
    public float cooldownTimer;

    // animation
    private Animator anim;

    // for locked doors
    public Inventory playerInventory;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (isOpen)
            {
                Close();
            }
            else
            {
                if ((thisDoorType == DoorType.locked) && (playerInventory.Key == 3))
                {
                    playerInventory.Key -= 3;
                    KeySignal.Raise();
                    thisDoorType = DoorType.normal;
                    Open();
                }
                else if (thisDoorType == DoorType.normal)
                {
                    Open();
                }
            }
        }
        // Main monster blocking the door
        // for now player does this
        else if (Input.GetKeyDown(KeyCode.B) && playerInRange)
        {
            cooldownTimer = cooldown;
            // if the door open to begin with
            if (isOpen)
            {
                Close();
            }
            if (thisDoorType == DoorType.normal)
            {
                thisDoorType = DoorType.blocked;
            }

        }
        BlockedDoorCooldown();
    }
    public void Open()
    {
        isOpen = true;
        anim.SetBool("opened", true);
        physicsCollider.enabled = false;
        
    }
    public void Close()
    {
        isOpen = false;
        anim.SetBool("opened", false);
        physicsCollider.enabled = true;
    }

    public void BlockedDoorCooldown()
    { 
        
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
            thisDoorType = DoorType.normal;
        }
    }

}
