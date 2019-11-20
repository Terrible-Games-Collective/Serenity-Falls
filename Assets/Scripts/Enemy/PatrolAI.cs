using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StateMachineTools;
using Pathfinding;

public class PatrolAI : MonoBehaviour
{

    //Patrol state
    public float patrolSpeed;       //The speed at which to patrol
    public float waitTime;          //How long to wait at each destination 
    public Transform[] moveSpots;   //Array of movespots that mark the patrol path
    public int destinationSpot = 0; //The index of the initial patrol target in moveSpots
    public Transform target;


    //Used by chase state
    public float chaseSpeed;        //The speed to chase the player

    //Used for testing timer switch
    private float gameTimer;
    private int seconds = 0;
    public int stateSeconds;
    private string currentState;

    FovDetection fov;
    public IAstarAI ai;



    public bool chasePlayer = false;//indicates which state is active

    public StateMachine<PatrolAI> stateMachine { get; set; }//Instance of the StateMachine class



    private void Start()
    {
        //When start is called, set the initial state to Patrol, start a timer, this will change states every stateSeconds seconds to demo
        stateMachine = new StateMachine<PatrolAI>(this);
        fov = GetComponent<FovDetection>();
        stateMachine.ChangeState(EnemyPatrolState.Instance);
        currentState = "patrol";
        gameTimer = Time.time;
        ai = GetComponent<IAstarAI>();
        // Update the destination right before searching for a path as well.
        // This is enough in theory, but this script will also update the destination every
        // frame as the destination is used for debugging and may be used for other things by other
        // scripts as well. So it makes sense that it is up to date every frame.
        if (ai != null) ai.onSearchPath += Update;

    }

    void OnDisable()
    {
        if (ai != null) ai.onSearchPath -= Update;
    }

    private void Update()
    {

        //waits until stateSeconds has passed before switching states
        //if (Time.time > gameTimer + 1)
        //{
        //    gameTimer = Time.time;
        //    seconds++;
        //    //Debug.Log(seconds);
        //}

        //if (seconds == stateSeconds)
        //{
        //    seconds = 0;
        //    chasePlayer = !chasePlayer;
        //}
        if (currentState != "chase" && fov.IsInView())
        {
            currentState = "chase";
            stateMachine.ChangeState(EnemyChaseState.Instance);
        } else if (currentState != "patrol" && !fov.IsInView()) {
            currentState = "patrol";
            stateMachine.ChangeState(EnemyPatrolState.Instance);
        }
        ai.destination = target.position;
        stateMachine.Update();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("YOU ARE DEAD");
        }
    }

}
