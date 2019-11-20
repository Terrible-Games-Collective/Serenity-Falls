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

    private MonsterBrain.monster_manager monsterBrain;

    GameObject CornerGirlPrefab;
    GameObject ClownPrefab;


    public override void EnterState(MonsterAI _owner)
    {
        _owner.currentState = MonsterAI.MonsterState.SpawnMinion;

        monsterBrain = _owner.GetMonster_Manager();

        spawnPoint = ChooseSpawnPoint();

        if (spawnPoint == null)
        {
            _owner.GoToNextState();
        }

        _owner.setTargetAsTransform(spawnPoint);



    }

    public override void ExitState(MonsterAI _owner)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(MonsterAI _owner)
    {
        if (_owner.isReachedTarget())
        {
            
            //Spawn prefab at location
            //Will need to add bit to minion scripts to increment the count.
            //Instantiate(CornerGirlPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //Instantiate(ClownPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            _owner.GoToNextState();
        }
    }

    public Transform ChooseSpawnPoint()
    {

        Room tempRoom;
        Sector sector;


        for(int i = 0; i < 4; i++)
        {
            if(monsterBrain.allSectors[i].containsClown == false || monsterBrain.allSectors[i].containsGirl == false)
            {
                sector = monsterBrain.allSectors[i];
                tempRoom = sector.getRandomRoom().GetComponent<Room>();
                return tempRoom.moveSpots[Random.Range(0, tempRoom.moveSpots.Length + 1)];
            }
        }


        return null;
    }
}
