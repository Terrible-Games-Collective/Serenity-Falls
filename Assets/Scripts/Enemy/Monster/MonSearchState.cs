using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonStalkState : State<MonsterAI>
{
    IAstarAI ai;
    private Transform target;
    //State Initialization ***************************
    private static MonStalkState _instance;

    private MonsterBrain.monster_manager monsterBrain;

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
		if (ai == null)
		{
			ai = _owner.GetComponent<IAstarAI>();
		}

		monsterBrain = _owner.GetMonster_Manager();
        target = monsterBrain.currentSector.getRandomRoom().transform;
        
    }

    public override void ExitState(MonsterAI _owner)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MonsterAI _owner)
    {
        _owner.target = target.transform;
    }
}
