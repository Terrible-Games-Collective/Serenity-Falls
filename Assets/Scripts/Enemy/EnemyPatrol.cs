using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{


    private int destinationSpot;
    private float waitTime;

    public float moveSpeed;
    public float startWaitTime;
    public Transform[] moveSpots;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        destinationSpot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[destinationSpot].position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[destinationSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                if (destinationSpot+1 == moveSpots.Length)
                {
                    destinationSpot = -1;
                }
                destinationSpot++;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
