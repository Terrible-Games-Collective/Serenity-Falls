using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineTools;
using Pathfinding;

public class EnemyPatrolState : State<PatrolAI>
{
    IAstarAI ai;
    private static EnemyPatrolState _instance;

    private float waitTimeCounter;

    private EnemyPatrolState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    //If no instance exists, create one
    public static EnemyPatrolState Instance
    {
        get
        {
            if(_instance == null)
            {
                new EnemyPatrolState();
            }

            return _instance;
        }
    }

    public override void EnterState(PatrolAI _owner)
    {
        //Debug.Log("Exiting Patrol State");
        _owner.target = _owner.moveSpots[_owner.destinationSpot];
        waitTimeCounter = _owner.waitTime; //resets the waitTime
        if(ai == null) {
            ai = _owner.GetComponent<IAstarAI>();
        }
        ai.maxSpeed = _owner.patrolSpeed;


    }

    public override void ExitState(PatrolAI _owner)
    {
        //Debug.Log("Exiting Patrol State");
    }

    public override void UpdateState(PatrolAI _owner)
    {
        if (_owner.chasePlayer)
        {
            _owner.stateMachine.ChangeState(EnemyChaseState.Instance); //change state if needed
        }
        else
        {
            //If the movespot was reached, wait the specified time before continuing
            Debug.Log((Vector2.Distance(_owner.transform.position, _owner.moveSpots[_owner.destinationSpot].position)).ToString());
            if (Vector2.Distance(_owner.transform.position, _owner.moveSpots[_owner.destinationSpot].position) < 0.5f)
            {
                Debug.Log("Got here guys");
                if (waitTimeCounter <= 0)
                {
                    if (_owner.destinationSpot + 1 == _owner.moveSpots.Length)
                    {
                        _owner.destinationSpot = -1;
                    }
                    _owner.destinationSpot++;
                    waitTimeCounter = _owner.waitTime;
                    _owner.target = _owner.moveSpots[_owner.destinationSpot];
                }
                else
                {
                    waitTimeCounter -= Time.deltaTime;
                }

            }
        }
            
    }

}
