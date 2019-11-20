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

    private GameObject breaker;
    private MonsterBrain.monster_manager monsterBrain;

    public override void EnterState(MonsterAI _owner)
    {
        _owner.currentState = MonsterAI.MonsterState.BreakerSwitch;

        monsterBrain = _owner.GetMonster_Manager();
        breaker = GameObject.Find("Breaker");

        _owner.setTarget(breaker);

    }

    public override void ExitState(MonsterAI _owner)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MonsterAI _owner)
    {
        if (_owner.isReachedTarget())
        {
            //TODO Use Start Coroutine once the new breaker code is in
            //Make sure to add something in that function to set breakerOn in monster brain when it changes
            breaker.GetComponent<Breaker>().UseBreaker();

            _owner.GoToNextState();
        }
    }
}
