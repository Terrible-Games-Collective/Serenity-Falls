using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineTools;
using Pathfinding;

public class EnemyChaseState : State<PatrolAI>
{

    private static EnemyChaseState _instance;

    private Transform target = null;
    IAstarAI ai;
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
        Debug.Log("Entering Chase State");

        if (target == null)
        {
            //get target to chase based off of their tag
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        if (ai == null)
        {
            ai = _owner.GetComponent<IAstarAI>();
        }
        _owner.target = target.transform;
        ai.maxSpeed = _owner.chaseSpeed;


    }

    public override void ExitState(PatrolAI _owner)
    {
        //Debug.Log("Exiting Chase State");
    }

    public override void UpdateState(PatrolAI _owner)
    {
            //update location based off of target position
            //_owner.transform.position = Vector2.MoveTowards(_owner.transform.position, target.position, _owner.chaseSpeed * Time.deltaTime);
            _owner.target = target.transform;

    }

}
