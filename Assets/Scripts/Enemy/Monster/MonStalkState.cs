using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonStalkState : State<MonsterAI>
{

    //State Initialization ***************************
    private static MonStalkState _instance;

    private MonStalkState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonStalkState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonStalkState();
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
