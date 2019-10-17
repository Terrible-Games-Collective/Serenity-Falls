using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float runBoost = 1f;

    public Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
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
        if (Input.GetAxisRaw("Run") == 1)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed + runBoost) * Time.fixedDeltaTime );
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
