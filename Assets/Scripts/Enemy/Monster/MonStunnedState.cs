using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonStunnedState : State<MonsterAI>
{

    //State Initialization ***************************
    private static MonStunnedState _instance;

    private MonStunnedState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonStunnedState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonStunnedState();
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
