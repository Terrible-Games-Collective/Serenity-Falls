using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    normal,
    locked
}
public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool isOpen;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
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
                if (thisDoorType == DoorType.locked && playerInventory.Key)
                {
                    playerInventory.Key = false;
                    thisDoorType = DoorType.normal;
                    Open();
                }
                else if (thisDoorType == DoorType.normal)
                {
                    Open();
                }
            }
        }
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

}
