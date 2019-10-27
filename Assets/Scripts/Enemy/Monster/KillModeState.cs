using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonKillModeState : State<MonsterAI>
{

    //State Initialization ***************************
    private static MonKillModeState _instance;

    private MonKillModeState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonKillModeState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonKillModeState();
            }

            return _instance;
        }
    }
    //*************************************************



    public override void EnterState(MonsterAI _owner)
    {
        throw new System.NotImplementedException();
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
