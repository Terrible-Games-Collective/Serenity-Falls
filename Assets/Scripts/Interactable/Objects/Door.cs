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
    private MonsterBrain monsterBrain;

    // blocked door
    public float cooldown;
    public float cooldownTimer;

    // animation
    private Animator anim;

    // for locked doors
    public Inventory playerInventory;

    // auto close after enemy open door
    private float cdd = 1;
    private float cddt = 0;
    private void Start()
    {
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
                // for the main locked door that needs 3 keys to open
                // when 3 keys are within player it removes all keys and turns door to normal
                // and opens it 
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
        else if (Input.GetKeyDown(KeyCode.B) && playerInRange && thisDoorType != DoorType.locked)
        {
            cooldownTimer = cooldown;
            doorSprite.color = Color.red;
            lightUIR.SetActive(true);
            lightUIG.SetActive(false);
            usable = false;
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
        else if (enemyInrange && thisDoorType == DoorType.normal)
        {
            if (!isOpen)
            {
                cddt = cdd;
                Open();
            }

        }
        
        AutoClose();
        
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
        // blocking door by monster make door unusable and glow red
        if (thisDoorType == DoorType.normal)
        {
            thisDoorType = DoorType.blocked;
            usable = false;
            doorSprite.color = Color.red;
            lightUIR.SetActive(true);
            monsterBrain.blockedDoors++;
        }
    }
    // open the door and set state to false also do animations and sound
    public void Open()
    {
        isOpen = true;
        anim.SetBool("opened", true);
        physicsCollider.enabled = false;
        GetComponent<DoorAudio>().PlaySound(transform.position, true);

    }
    // close the door and set state to false also do animations and sound
    public void Close()
    {
        isOpen = false;
        anim.SetBool("opened", false);
        physicsCollider.enabled = true;
        GetComponent<DoorAudio>().PlaySound(transform.position, false);
    }

    // cooldown for the blocked door
    // counts down until 0 and then set door back to normal
    // also highlights green if player in range
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
            monsterBrain.blockedDoors--;
            usable = true;
            // for the UI interaction on what color to glow
            if (playerInRange)
            {
                if (usable)
                {
                    item.color = Color.green;
                    lightUIG.SetActive(true);
                }
                else
                {
                    item.color = Color.red;
                    lightUIR.SetActive(true);
                }

            }
            else
            {
                item.color = Color.white;
                lightUIG.SetActive(false);
                lightUIR.SetActive(false);
            }


        }
    }
    // cooldown for close door after enemy open
    public void AutoClose()
    {

        if (cddt > 0)
        {
            cddt -= Time.deltaTime;
        }
        if (cddt < 0)
        {
            cddt = 0;
            Close();
        }
    }
}