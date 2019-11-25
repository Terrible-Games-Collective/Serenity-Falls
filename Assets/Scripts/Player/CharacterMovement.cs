using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    Vector2 movement;

    public float moveSpeed;
    public float runBoost;
    public int cooldownTimer;
    public int runBoostTimer;
    private int burstCooldown;
    private int enterCooldown = 0;
    private int runBurst;
    private int runHold = 0;

    void Start()
    {
        runBurst = runBoostTimer;
        burstCooldown = cooldownTimer;

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        // input in update
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        // movement in fixed

        if (runBurst == 0)
        {
            enterCooldown = 1;
            runHold = 0;
        }

        if (enterCooldown == 1)
        {
            burstCooldown--;
        }

        if (burstCooldown == 0 && enterCooldown == 1)
        {
            burstCooldown = cooldownTimer;
            enterCooldown = 0;
            runBurst = runBoostTimer;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            runHold = 1;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            runHold = 0;
        }

        if (runHold == 1 && enterCooldown == 0)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed + runBoost) * Time.fixedDeltaTime );
            runBurst--;
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        //Debug.Log(runBoost);
    }
}
