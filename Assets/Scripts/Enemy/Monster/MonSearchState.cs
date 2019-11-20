using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonSearchState : State<MonsterAI>
{
    //State Initialization ***************************
    private static MonSearchState _instance;

    private MonsterBrain.monster_manager monsterBrain;

    private MonSearchState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonSearchState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonSearchState();
            }

            return _instance;
        }
    }
    //*************************************************



    public override void EnterState(MonsterAI _owner) {

		monsterBrain = _owner.GetMonster_Manager();
        Sector sector = monsterBrain.currentSector;
        Debug.Log(sector);
        GameObject gameRoom = sector.getRandomRoom();
        Room room = gameRoom.GetComponent<Room>();
        _owner.setTargetAsTransform(room.moveSpots[0]);
        
    }

    public override void ExitState(MonsterAI _owner)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MonsterAI _owner)
    {
        if (_owner.GetFovDetection().IsInView())
        {
            _owner.InView(true);
            _owner.GoToNextState();
        } else
        {
            _owner.InView(false);
        }

        if (_owner.isReachedTarget()) {
            _owner.setTargetAsTransform(monsterBrain.currentSector.getRandomRoom().GetComponent<Room>().moveSpots[0]);
        }
    }
}
