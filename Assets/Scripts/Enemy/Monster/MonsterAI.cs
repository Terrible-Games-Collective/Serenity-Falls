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

        //Debug.Log("Timer:"+(Time.unscaledTime - startStateTime));
        //Debug.Log(stateChangeInterval);
        //Debug.Log(Time.unscaledTime - startStateTime > stateChangeInterval);

        if (Time.unscaledTime - startStateTime > stateChangeInterval) {
            startStateTime = Time.unscaledTime;
            searching = !searching;
            GoToNextState();
        }



       

        ai.destination = target.position;
        stateMachine.Update();
    }

    public MonsterBrain GetMonsterBrain() {
        return monsterBrain;
    }

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

    //Set forceTransition to true if you want the monster to stop what it is doing and go to the next state
    public void GoToNextState(bool forceTransition = true)
    {
        //Debug.Log("Go To next State");
        //Debug.Log(searching);

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


    private MonsterState DecideNextSearchState()
    {
        return MonsterState.Search;
    }

    private MonsterState DecideNextTrapState()
    {
        if (monsterBrain.breakerOn)
            return MonsterState.BreakerSwitch;

        else if (monsterBrain.minionsSpawned < monsterBrain.blockedDoors && monsterBrain.minionsSpawned < monsterBrain.maxMinions)
            return MonsterState.SpawnMinion;

        else
            return MonsterState.BlockDoor;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
            Debug.Log("YOU ARE DEAD");
        }
    }

    public bool isReachedTarget() {
        return (Vector2.Distance(transform.position, target.position) < 0.5f);
    }

    public FovDetection GetFovDetection()
    {
        return fov;
    }

    public void setTarget(GameObject tar)
    {
        target = tar.GetComponent<Transform>();
        ai.destination = target.position;
    }

    public void setTargetAsTransform(Transform tar)
    {
        target = tar;
        ai.destination = target.position;
    }

    public void InView(bool seen)
    {
        if(seen != seenPlayer)
        {
            seenPlayer = seen;
        }
    }
    public void SpawnMinion(GameObject minionPrefab, Transform location)
    {
        Instantiate(minionPrefab, new Vector3(transform.position.x, transform.position.y), location.rotation);

    }

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
