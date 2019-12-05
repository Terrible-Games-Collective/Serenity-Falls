using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonSpawnMinionState : State<MonsterAI>
{

    //State Initialization ***************************
    private static MonSpawnMinionState _instance;

    private MonSpawnMinionState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonSpawnMinionState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonSpawnMinionState();
            }

            return _instance;
        }
    }
    //*************************************************

    Transform spawnPoint;

    private MonsterBrain monsterBrain;
    GameObject MinionToSpawn;


    public override void EnterState(MonsterAI _owner)
    {
        _owner.currentState = MonsterAI.MonsterState.SpawnMinion;

        monsterBrain = _owner.GetMonsterBrain();

        spawnPoint = ChooseSpawnPoint(_owner);

        if (spawnPoint == null)
        {
            _owner.GoToNextState();
        }

        //_owner.setTargetAsTransform(spawnPoint);
        _owner.target = spawnPoint;



    }

    public override void ExitState(MonsterAI _owner)
    {
        
    }

    public override void UpdateState(MonsterAI _owner)
    {
        if (_owner.isReachedTarget())
        {
            //Spawn prefab at location
            //Will need to add bit to minion scripts to increment the count.
            _owner.SpawnMinion(MinionToSpawn, spawnPoint);

            _owner.GoToNextState();
        }
    }

    public Transform ChooseSpawnPoint(MonsterAI _owner)
    {

        Room tempRoom;
        Sector sector;


        int i = Random.Range(0, 4); //choose random sector
        int type = Random.Range(0, 2); //randomly choose type of monster
           
        sector = monsterBrain.allSectors[i];
        tempRoom = sector.getRandomRoom().GetComponent<Room>();

        if (type == 0)
        {
            MinionToSpawn = _owner.CornerGhostPrefab;
        }
        else
        {
            MinionToSpawn = _owner.ClownPrefab;
        }


        return tempRoom.moveSpots[Random.Range(0, tempRoom.moveSpots.Length)];
    }
}
