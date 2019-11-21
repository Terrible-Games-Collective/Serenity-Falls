using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonIntimidateState : State<MonsterAI>
{

    //State Initialization ***************************
    private static MonIntimidateState _instance;
    private float timeStart;
    private int index;
    public bool finished;

    private MonIntimidateState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonIntimidateState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonIntimidateState();
            }

            return _instance;
        }
    }
    //*************************************************



    public override void EnterState(MonsterAI _owner)
    {
        index = 0;
        _owner.currentState = MonsterAI.MonsterState.Intimidate;
        Debug.Log(_owner.GetMonsterBrain().currentSector.playersRoom);
        _owner.setTargetAsTransform(_owner.GetMonsterBrain().currentSector.playersRoom.moveSpots[index]);

    }

    public override void ExitState(MonsterAI _owner)
    {

    }

    public override void UpdateState(MonsterAI _owner)
    {
        Transform[] moveSpots = _owner.GetMonsterBrain().currentSector.playersRoom.moveSpots;
        if (_owner.isReachedTarget()){
            if(index+1 < moveSpots.Length)
            {
                index++;
                _owner.setTargetAsTransform(moveSpots[index]);
            } else
            {
                _owner.GoToNextState();
            }
        }
    }
}
