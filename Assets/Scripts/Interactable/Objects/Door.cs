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
    public Signal DoorSignal;
    private MonsterBrain monsterBrain;

    // blocked door
    public float cooldown;
    public float cooldownTimer;

    // animation
    private Animator anim;

    // for locked doors
    public Inventory playerInventory;
    private void Start()
    {
        // animation for the doors
        anim = GetComponent<Animator>();

        monsterBrain = GameObject.FindWithTag("Monster").GetComponent<MonsterBrain>();
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
                // need 3 keys to open locked door and the door type has to be locked
                // inventory will remove 3 keys and signal KeyUI to update keys on screen
                // change the door type to normal when its unlocked
                if ((thisDoorType == DoorType.locked) && (playerInventory.Key == 3))
                {
                    playerInventory.Key -= 3;
                    KeySignal.Raise();
                    thisDoorType = DoorType.normal;
                    Open();
                }
                else if ((thisDoorType == DoorType.locked) && (playerInventory.Key < 3)){
                    DoorSignal.Raise();
                }
                else if (thisDoorType == DoorType.normal)
                {
                    Open();
                }
            }
        }
        // Main monster blocking the door
        // for now player does this
        else if (Input.GetKeyDown(KeyCode.B) && playerInRange && thisDoorType != DoorType.locked)
        {
            cooldownTimer = cooldown;
            doorSprite.color = Color.red;
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

    //Used by the monster to block doors
    public void BlockDoor()
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
            monsterBrain.blockedDoors++;
        }
    }

    public void Open()
    {
        // opens the door by just removing collider and animation
        isOpen = true;
        anim.SetBool("opened", true);
        physicsCollider.enabled = false;
        GetComponent<DoorAudio>().PlaySound(transform.position, true);
        
    }
    public void Close()
    {
        // close the door by enabling collider and doing the animation
        isOpen = false;
        anim.SetBool("opened", false);
        physicsCollider.enabled = true;
        GetComponent<DoorAudio>().PlaySound(transform.position, false);
    }

    public void BlockedDoorCooldown()
    {
        // cooldown for the door and set door type to blocked
        // cooldown timer goes down until 0 then door type became unblocked
        // also changed the color of the door when blocked

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
            thisDoorType = DoorType.normal;
            monsterBrain.blockedDoors--;
            
            if (playerInRange)
            {
                item.color = Color.green;
            }
            else
            {
                item.color = Color.white;
            }
            

        }
    }

}
