using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Interactable
{
    public EdgeCollider2D physicsCollider;
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (!isOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }
    public void Open()
    {

        isOpen = true;
        physicsCollider.enabled = false;
    }
    public void Close()
    {
        isOpen = false;
        physicsCollider.enabled = true;
    }
}
