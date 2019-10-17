using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineTools;

public class EnemyPatrolState : State<PatrolAI>
{

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
        waitTimeCounter = _owner.waitTime; //resets the waitTime

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
            //Starts the movement towards the next move spot
            _owner.transform.position = Vector2.MoveTowards(_owner.transform.position,
                            _owner.moveSpots[_owner.destinationSpot].position, _owner.patrolSpeed * Time.deltaTime);


            //If the movespot was reached, wait the specified time before continuing
            if (Vector2.Distance(_owner.transform.position, _owner.moveSpots[_owner.destinationSpot].position) < 0.2f)
            {
                if (waitTimeCounter <= 0)
                {
                    if (_owner.destinationSpot + 1 == _owner.moveSpots.Length)
                    {
                        _owner.destinationSpot = -1;
                    }
                    _owner.destinationSpot++;
                    waitTimeCounter = _owner.waitTime;
                }
                else
                {
                    waitTimeCounter -= Time.deltaTime;
                }
            }
        }
            
    }

}
