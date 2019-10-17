using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineTools;

public class PatrolAI : MonoBehaviour
{

    //Patrol state
    public float patrolSpeed;       //The speed at which to patrol
    public float waitTime;          //How long to wait at each destination 
    public Transform[] moveSpots;   //Array of movespots that mark the patrol path
    public int destinationSpot = 0; //The index of the initial patrol target in moveSpots

    //Used by chase state
    public float chaseSpeed;        //The speed to chase the player

    //Used for testing timer switch
    private float gameTimer;
    private int seconds = 0;
    public int stateSeconds;

    
    public bool chasePlayer = false;//indicates which state is active

    public StateMachine<PatrolAI> stateMachine { get; set; }//Instance of the StateMachine class


    private void Start()
    {
        //When start is called, set the initial state to Patrol, start a timer, this will change states every stateSeconds seconds to demo
        stateMachine = new StateMachine<PatrolAI>(this);
        stateMachine.ChangeState(EnemyPatrolState.Instance);
        gameTimer = Time.time;

    }

    private void Update()
    {

        //waits until stateSeconds has passed before switching states
        if (Time.time > gameTimer + 1)
        {
            gameTimer = Time.time;
            seconds++;
            //Debug.Log(seconds);
        }

        if (seconds == stateSeconds)
        {
            seconds = 0;
            chasePlayer = !chasePlayer;
        }


        stateMachine.Update();

    }

}
