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
    public enum MonsterState { Idle, Stunned, Stalk, BlockDoor,  BreakerSwitch, SpawnMinion, KillMode };
    public MonsterState currentState;

    public StateMachine<MonsterAI> stateMachine { get; set; }//Instance of the StateMachine class
    //end of state machine stuff*********

    private IAstarAI ai;

    public Transform target;
    public int idleSeconds;

    private float startTime;
    public float timeBetweenStates;

    public float chaseSpeed;
    public float killModeSpeed;

    protected MonsterBrain.monster_manager monsterBrain;
   




    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.fixedUnscaledTime;
        stateMachine = new StateMachine<MonsterAI>(this);
        ai = GetComponent<IAstarAI>();
        monsterBrain = GetComponent<MonsterBrain>().monster_brain;



        stateMachine.ChangeState(MonIdleState.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.fixedUnscaledTime - startTime > timeBetweenStates) {
            GoToNextState();
            startTime = Time.fixedUnscaledTime;
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
        MonsterState nextState = DecideNextState();

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

    private MonsterState DecideNextState() {
        //if (monsterBrain.remainingKeys.Count == 3) {
        //    if(monsterBrain.blockedDoors < 3) {
        //        return MonsterState.BlockDoor;
        //    }
        //    return MonsterState.Stalk;
        //}

        //if(monsterBrain.remainingKeys.Count == 2) {
        //    if (monsterBrain.breakerOn) {
        //        return MonsterState.BreakerSwitch;
        //    }
        //    else if(monsterBrain.blockedDoors < 4) {
        //        return MonsterState.BlockDoor;
        //    }
        //    return MonsterState.Stalk;
        //}

        //if(monsterBrain.remainingKeys.Count == 1) {
        //    if (monsterBrain.breakerOn) {
        //        return MonsterState.BreakerSwitch;
        //    }
        //    else if (monsterBrain.minionsSpawned < monsterBrain.maxMinions) {
        //        return MonsterState.SpawnMinion;
        //    }
        //    else if (monsterBrain.blockedDoors < 4) {
        //        return MonsterState.BlockDoor;
        //    }
        //    return MonsterState.Stalk;
        //}

        //if(monsterBrain.remainingKeys.Count == 0) {
        //    return MonsterState.KillMode;
        //}

        return MonsterState.Stalk;
    }


    //Called by player when monster is in fov
    private void  ApplyStun()
    { 
         stateMachine.ChangeState(MonStunnedState.Instance); 
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
