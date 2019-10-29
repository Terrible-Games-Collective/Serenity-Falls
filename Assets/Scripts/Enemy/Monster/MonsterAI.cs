using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineTools;
using Pathfinding;

public class MonsterAI : MonoBehaviour
{
    //State Machine Stuff****************
    //Enum to keep track of state
    public enum MonsterState { Idle, Stalk, Stunned, BlockDoor,  BreakerSwitch, SpawnMinion, KillMode };
    public MonsterState currentState;

    public StateMachine<MonsterAI> stateMachine { get; set; }//Instance of the StateMachine class
    //end of state machine stuff*********

    private IAstarAI ai;

    public Transform target;
    public int idleSeconds;
   




    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine<MonsterAI>(this);
        ai = GetComponent<IAstarAI>();



        stateMachine.ChangeState(MonIdleState.Instance);
    }

    // Update is called once per frame
    void Update()
    {



        ai.destination = target.position;
        stateMachine.Update();
    }

    //Set interupt to true if you want the monster to stop what it is doing and go to the next state
    public void GoToNextState(bool interupt = false)
    {
        MonsterState nextState = DecideNextState();

        //If interupt is true and the current state is deemed the best state the monster will
        //enter it's current state again, if interupt is false and the current state is the best
        //it will continue what it is doing
        if (nextState == currentState && !interupt) 
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
            case MonsterState.Stunned:
                stateMachine.ChangeState(MonStunnedState.Instance);
                break;
            case MonsterState.Idle:
                stateMachine.ChangeState(MonIdleState.Instance);
                break;
        }
    }

    private MonsterState DecideNextState()
    {
        //Use if statements to examine the game state and decide what to do

        //if (remainingKeys.count == 0)
        //{
        //return MonsterState.KillMode;
        //}

       




        return MonsterState.Idle;
    }

}
