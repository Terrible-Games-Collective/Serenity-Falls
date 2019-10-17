using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineTools;

public class EnemyChaseState : State<PatrolAI>
{

    private static EnemyChaseState _instance;

    private Transform target = null;

    private EnemyChaseState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static EnemyChaseState Instance
    {
        get
        {
            if (_instance == null)
            {
                new EnemyChaseState();
            }

            return _instance;
        }
    }

    public override void EnterState(PatrolAI _owner)
    {
        //Debug.Log("Entering Chase State");

        if (target == null)
        {
            //get target to chase based off of their tag
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        
        
    }

    public override void ExitState(PatrolAI _owner)
    {
        //Debug.Log("Exiting Chase State");
    }

    public override void UpdateState(PatrolAI _owner)
    {
        if (!_owner.chasePlayer)
        {
            _owner.stateMachine.ChangeState(EnemyPatrolState.Instance); //change state if needed
        }
        else
        {
            //update location based off of target position
           _owner.transform.position = Vector2.MoveTowards(_owner.transform.position, target.position, _owner.chaseSpeed * Time.deltaTime);
        }
    }

}
