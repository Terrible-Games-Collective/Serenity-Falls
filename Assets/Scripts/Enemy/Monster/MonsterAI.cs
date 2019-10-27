using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineTools;
using Pathfinding;

public class MonsterAI : MonoBehaviour
{

    //Enum to keep track of state
    enum MonsterState { Idle, Stalk, Stunned, BlockDoor,  BreakerSwitch, SpawnMinion, KillMode };
    MonsterState currentState;

    public StateMachine<MonsterAI> stateMachine { get; set; }//Instance of the StateMachine class

    


    // Start is called before the first frame update
    void Start()
    {
        currentState = MonsterState.Idle;     
        



    }

    // Update is called once per frame
    void Update()
    {





        //stateMachine.Update();
    }
}
