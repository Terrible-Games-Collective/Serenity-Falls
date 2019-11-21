using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonBlockDoorState : State<MonsterAI>
{

    //State Initialization ***************************
    private static MonBlockDoorState _instance;

    private MonBlockDoorState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonBlockDoorState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonBlockDoorState();
            }

            return _instance;
        }
    }
    //*************************************************

    private GameObject door;

    private MonsterBrain monsterBrain;

    public override void EnterState(MonsterAI _owner)
    {
        _owner.currentState = MonsterAI.MonsterState.BlockDoor;

        monsterBrain = _owner.GetMonsterBrain();

        

        door = pickRoomDoor();

        

        _owner.setTarget(door);



    }

    public override void ExitState(MonsterAI _owner)
    {
        
    }


    public override void UpdateState(MonsterAI _owner)
    {
        if (_owner.isReachedTarget())
        {

            door.GetComponent<Door>().BlockDoor();

            _owner.GoToNextState();
        }
    }


    //Will select a unblocked door
    private GameObject pickRoomDoor()
    {
        Room tempRoom;
        GameObject tempDoor;
        Sector sector;

        bool roomFound = false;

        while (!roomFound)
        {
            sector = monsterBrain.GetSectorWithKey();

            //If there are no keys left it will go to block doors in the players section, else pick a sector that still has a key
            if (sector == null)
                tempRoom = monsterBrain.currentSector.getRandomRoom().GetComponent<Room>();
            else
                tempRoom = sector.getRandomRoom().GetComponent<Room>();


            if (tempRoom.doors.Length != 0)
            {
                for (int j = 0; j < tempRoom.doors.Length; j++)
                {
                    tempDoor = tempRoom.doors[j];
                    if (tempDoor.GetComponent<Door>().thisDoorType == DoorType.normal)
                    {
                        return tempDoor;
                    }
                }
            }
        }

        return null;
    }
}
