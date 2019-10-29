using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonBreakerSwitchState : State<MonsterAI>
{

    //State Initialization ***************************
    private static MonBreakerSwitchState _instance;

    private MonBreakerSwitchState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonBreakerSwitchState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonBreakerSwitchState();
            }

            return _instance;
        }
    }
    //*************************************************



    public override void EnterState(MonsterAI _owner)
    {
        _owner.currentState = MonsterAI.MonsterState.BreakerSwitch;
    }

    public override void ExitState(MonsterAI _owner)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MonsterAI _owner)
    {
        throw new System.NotImplementedException();
    }
}
