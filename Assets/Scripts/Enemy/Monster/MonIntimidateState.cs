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


    private MonsterBrain monsterBrain;
    private Room playerRoom;
    private Transform[] moveSpots;

    public override void EnterState(MonsterAI _owner)
    {
        
        _owner.currentState = MonsterAI.MonsterState.Intimidate;

        monsterBrain = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterBrain>();
        playerRoom = monsterBrain.currentSector.playersRoom.GetComponent<Room>();
        moveSpots = playerRoom.moveSpots;
        index = 0;

        _owner.target = moveSpots[index];
        _owner.PlayGiveUpSound();
    }

    public override void ExitState(MonsterAI _owner)
    {
        _owner.PlayGiveUpSound();
    }

    public override void UpdateState(MonsterAI _owner)
    {
        
        if (_owner.isReachedTarget()){
            if(index < moveSpots.Length)
            {
                index++;
            } else
            {
                _owner.GoToNextState();
            }
        }
        _owner.target = moveSpots[index];
    }
}
