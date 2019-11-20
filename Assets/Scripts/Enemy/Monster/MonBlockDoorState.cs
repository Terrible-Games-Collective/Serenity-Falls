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

    private MonsterBrain.monster_manager monsterBrain;

    public override void EnterState(MonsterAI _owner)
    {

        monsterBrain = _owner.GetMonster_Manager();

        door = pickRoomDoor();

        _owner.setTarget(door);



    }

    public override void ExitState(MonsterAI _owner)
    {
        throw new System.NotImplementedException();
    }


    public override void UpdateState(MonsterAI _owner)
    {
        if (_owner.isReachedTarget())
            door.GetComponent<Door>().BlockDoor();
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
                tempRoom = monsterBrain.currentSector.getRandomRoom();
            else
                tempRoom = sector.getRandomRoom();


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
