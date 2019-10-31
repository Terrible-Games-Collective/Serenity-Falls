using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonIdleState : State<MonsterAI>
{

    //State Initialization ***************************
    private static MonIdleState _instance;

    private MonIdleState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonIdleState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonIdleState();
            }

            return _instance;
        }
    }
    //*************************************************


    private float idleTimer;
    private int seconds = 0;

    



    public override void EnterState(MonsterAI _owner)
    {
        _owner.currentState = MonsterAI.MonsterState.Idle;
        idleTimer = Time.time;
         
}

    public override void ExitState(MonsterAI _owner)
    {
       
    }

    public override void UpdateState(MonsterAI _owner)
    {
        //waits until idleSeconds has passed before trying to switch states
        if (Time.time > idleTimer + 1)
        {
            idleTimer = Time.time;
            seconds++;
            //Debug.Log(seconds);
        }

        if (seconds == _owner.idleSeconds)
        {
            seconds = 0;
            _owner.GoToNextState();
        }
    }
}
