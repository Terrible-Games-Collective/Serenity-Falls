﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform[] movespots;
    private int randomSpot;
   

    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, movespots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movespots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movespots[randomSpot].position) < 0.2f) {
            if(waitTime <= 0) {
                randomSpot = Random.Range(0, movespots.Length);
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}