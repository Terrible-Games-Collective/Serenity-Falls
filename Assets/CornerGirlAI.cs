using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerGirlAI : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D girlBd;
    Transform girlTrans;
    float girlWidth;

    public bool detected = false;
    bool firstDetection = false;

    void detectAction()
    {
        if (!firstDetection)
        {
            firstDetection = true;
        }

        speed = speed + 0.5f;


        Vector2 girlVel = girlBd.velocity;
        girlVel.x = speed;
        girlBd.velocity = girlVel;


    }

    // Start is called before the first frame update
    void Start()
    {
        //get variables
        girlBd = this.GetComponent<Rigidbody2D>();
        girlTrans = this.transform;
        girlWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;

    }

    void FixedUpdate()
    {
        //Vector to determine if girl is against a wall
        Vector2 lineCastPos = girlTrans.position - girlTrans.right * girlWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.right);
        bool isAgainstWall = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.right, enemyMask);

        if(detected)
        {
            detectAction();
        }

        //if against a wall        
        if(isAgainstWall)
        {
            //stop moving, no longer detected
            speed = 0;
            detected = false;
        }

        //movement for enemy when activated
        Vector2 girlVel = girlBd.velocity;
        girlVel.x = speed;
        girlBd.velocity = girlVel;
    }
}
