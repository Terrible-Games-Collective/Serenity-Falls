using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StateMachineTools;
using Pathfinding;

public class MonsterAI : MonoBehaviour
{
    //State Machine Stuff****************
    //Enum to keep track of state
    public enum MonsterState { Idle, Intimidate, Search, BlockDoor,  BreakerSwitch, SpawnMinion, KillMode };
    public MonsterState currentState;

    public StateMachine<MonsterAI> stateMachine { get; set; }//Instance of the StateMachine class
    //end of state machine stuff*********

    private IAstarAI ai;

    public Transform target;
    public int idleSeconds;

    public float normalSpeed;
    public float killModeSpeed;

    private FovDetection fov;

    public GameObject CornerGirlPrefab;
    public GameObject ClownPrefab;


    protected MonsterBrain monsterBrain;

    private float startStateTime;
    public int stateChangeInterval = 30;
    private bool searching;
    private bool seenPlayer;





    // Start is called before the first frame update
    void Start()
    {
        startStateTime = Time.unscaledTime;
        stateMachine = new StateMachine<MonsterAI>(this);
        ai = GetComponent<IAstarAI>();
        fov = GetComponent<FovDetection>();
        monsterBrain = GetComponent<MonsterBrain>();



        GoToNextState();
    }

    // Update is called once per frame
    void Update()
    {
        //If the mode switch timer is done then switch modes and pick a new state.
        if (Time.unscaledTime - startStateTime > stateChangeInterval) {
            startStateTime = Time.unscaledTime;
            searching = !searching;
            GoToNextState();
        }

        //If the player has been spotted go kill 
        if (fov.IsInView() && currentState != MonsterState.KillMode)
        {
            ChangeState(MonsterState.KillMode);
        }
        ai.destination = target.position;

        stateMachine.Update();
    }


    //Deprecated
    //Will return the monsterbrain component
    public MonsterBrain GetMonsterBrain() {
        return monsterBrain;
    }


    //Checks if the player has been seen
    public void checkForPlayer()
    {
        if (fov.IsInView())
        {
            InView(true);
            GoToNextState();
        }
        else
        {
            InView(false);
        }
    }


    //Used to transition the monster to a new state
    //Set forceTransition to true if you want the monster to stop what it is doing and go to the next state
    public void GoToNextState(bool forceTransition = true)
    {

        MonsterState nextState;


        if (seenPlayer)
        {
            ai.maxSpeed = killModeSpeed;
            nextState = MonsterState.KillMode;
        }
        else
        {
            ai.maxSpeed = normalSpeed;
            if (searching || monsterBrain.keysLeft <= 0)
            {
                //Debug.Log("Decided Search");
                nextState = DecideNextSearchState();
            }
            else
            {
                //Debug.Log("Decided Trap");
                nextState = DecideNextTrapState();
            }

            

            // If forceTransition is true and the current state is deemed the best state the monster will
            // enter it's current state again, if forceTransition is false and the current state is the best
            // it will continue what it is doing
            if (nextState == currentState && !forceTransition)
            {
                return;
            }
        }
            ChangeState(nextState);
        
    }

    //Descision tree for search state, currently will always start in search
    private MonsterState DecideNextSearchState()
    {
        return MonsterState.Search;
    }


    //Decides the next trap state to go into
    private MonsterState DecideNextTrapState()
    {
        if (monsterBrain.breakerOn)
            return MonsterState.BreakerSwitch;

        else if (monsterBrain.minionsSpawned < monsterBrain.blockedDoors && monsterBrain.minionsSpawned < monsterBrain.maxMinions)
            return MonsterState.SpawnMinion;

        else
            return MonsterState.BlockDoor;
    }


    //Triggers game over state when the player touches the monster
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
            Debug.Log("YOU ARE DEAD");
        }
    }

    //Used to check if the monster has reached its current target
    public bool isReachedTarget() {
        return (Vector2.Distance(transform.position, target.position) < 0.5f);
    }

    //Returns the fov script of the monster
    public FovDetection GetFovDetection()
    {
        return fov;
    }


    //Deprecated
    //Sets the monsters target to the given game object
    public void setTarget(GameObject tar)
    {
        target = tar.GetComponent<Transform>();
       // ai.destination = target.position;
    }

    //Deprecated
    //Sets the monsters target to the given transform
    public void setTargetAsTransform(Transform tar)
    {
        
        target = tar;
        //ai.destination = target.position;
    }

    //Function to check if player is in view
    public void InView(bool seen)
    {
        if(seen != seenPlayer)
        {
            seenPlayer = seen;
        }
    }



    //Spawns the given mini monster at the given location
    public void SpawnMinion(GameObject minionPrefab, Transform location)
    {
        Instantiate(minionPrefab, new Vector3(transform.position.x, transform.position.y), location.rotation);

    }


    //Actually changes the monsters state to the given state, useful to force a state change to a specific state
    public void ChangeState(MonsterState nextState)
    {
        switch (nextState)
        {
            case MonsterState.BlockDoor:
                stateMachine.ChangeState(MonBlockDoorState.Instance);
                break;
            case MonsterState.BreakerSwitch:
                stateMachine.ChangeState(MonBreakerSwitchState.Instance);
                break;
            case MonsterState.KillMode:
                stateMachine.ChangeState(MonKillModeState.Instance);
                break;
            case MonsterState.SpawnMinion:
                stateMachine.ChangeState(MonSpawnMinionState.Instance);
                break;
            case MonsterState.Search:
                stateMachine.ChangeState(MonSearchState.Instance);
                break;
            case MonsterState.Intimidate:
                stateMachine.ChangeState(MonIntimidateState.Instance);
                break;
            case MonsterState.Idle:
                stateMachine.ChangeState(MonIdleState.Instance);
                break;

        }
    }
}
