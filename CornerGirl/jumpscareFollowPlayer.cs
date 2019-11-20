using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareFollowPlayer : MonoBehaviour
{

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 moves;
    public float moveSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Debug.Log(direction);
        //direction.Normalize();
        //moves = direction;
    }
    /**
    private void FixedUpdate()
    {
        moveCharacter(moves);
    }
    **/

    /**
    void moveCharacter(Vector2 movement)
    {
        rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.deltaTime));
    }
    **/
}
