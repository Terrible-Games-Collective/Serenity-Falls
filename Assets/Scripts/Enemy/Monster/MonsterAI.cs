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
    public enum MonsterState { Idle, Intimidate, Stalk, BlockDoor,  BreakerSwitch, SpawnMinion, KillMode };
    public MonsterState currentState;

    public StateMachine<MonsterAI> stateMachine { get; set; }//Instance of the StateMachine class
    //end of state machine stuff*********

    private IAstarAI ai;

    public Transform target;
    public int idleSeconds;

    public float chaseSpeed;
    public float killModeSpeed;

    protected MonsterBrain.monster_manager monsterBrain;

    private float startStateTime;
    public int stateChangeInterval = 30;
    private bool searching;





    // Start is called before the first frame update
    void Start()
    {
        startStateTime = Time.fixedUnscaledTime;
        stateMachine = new StateMachine<MonsterAI>(this);
        ai = GetComponent<IAstarAI>();
        monsterBrain = GetComponent<MonsterBrain>().manager;



        stateMachine.ChangeState(MonIdleState.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.fixedUnscaledTime - startStateTime > stateChangeInterval) {
            GoToNextState();
            startStateTime = Time.fixedUnscaledTime;
        }


        ai.destination = target.position;
        stateMachine.Update();
    }

    public MonsterBrain.monster_manager GetMonster_Manager() {
        return monsterBrain;
    }

    //Set forceTransition to true if you want the monster to stop what it is doing and go to the next state
    public void GoToNextState(bool forceTransition = false)
    {
        MonsterState nextState = DecideNextTrapState();

        //If forceTransition is true and the current state is deemed the best state the monster will
        //enter it's current state again, if forceTransition is false and the current state is the best
        //it will continue what it is doing
        if (nextState == currentState && !forceTransition) 
        {
            return;
        }


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
            case MonsterState.Stalk:
                stateMachine.ChangeState(MonStalkState.Instance);
                break;
            case MonsterState.Idle:
                stateMachine.ChangeState(MonIdleState.Instance);
                break;
        }
    }


    private MonsterState DecideNextSearchState()
    {
        return MonsterState.Idle;
    }

    private MonsterState DecideNextTrapState()
    {
        return MonsterState.Idle;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("YOU ARE DEAD");
        }
    }

    public bool isReachedTarget() {
        return (Vector2.Distance(transform.position, target.position) < 0.5f);
    }

    public FovDetection GetFovDetection()
    {
        return GetComponent<FovDetection>();
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
}
