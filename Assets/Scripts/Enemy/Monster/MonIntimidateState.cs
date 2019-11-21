﻿using System.Collections;
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


    //This state will go to the room the player awas last in and the search it 
    //After it has searched all the points it will go to the next state.


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

        //_owner.setTargetAsTransform(moveSpots[index]);
        _owner.target = moveSpots[index];
        //Debug.Log(_owner.target);
    }

    public override void ExitState(MonsterAI _owner)
    {

    }

    public override void UpdateState(MonsterAI _owner)
    {
        
        if (_owner.isReachedTarget()){
            if(index < moveSpots.Length)
            {
                index++;
                //_owner.setTargetAsTransform(moveSpots[index]);
                _owner.target = moveSpots[index];
            } else
            {
                _owner.GoToNextState();
            }
        }
    }
}
