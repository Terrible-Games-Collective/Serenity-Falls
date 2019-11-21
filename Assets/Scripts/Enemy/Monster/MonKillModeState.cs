﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineTools;
using Pathfinding;

public class MonKillModeState : State<MonsterAI>
{
    IAstarAI ai;
    private Transform target;
    //State Initialization ***************************
    private static MonKillModeState _instance;
    private bool startedTimer;
    private float startTime;

    private MonKillModeState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    //If no instance exists, create one
    public static MonKillModeState Instance
    {
        get
        {
            if (_instance == null)
            {
                new MonKillModeState();
            }

            return _instance;
        }
    }
    //*************************************************


    //This state will follow the player until it kills them or they break line of sight for 3 seconds
    //Breaking line of sight will 3 seconds will transition to intimidate mode

    public override void EnterState(MonsterAI _owner)
    {
        _owner.currentState = MonsterAI.MonsterState.KillMode;
        if (target == null) {
            //get target to chase based off of their tag
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        if (ai == null) {
            ai = _owner.GetComponent<IAstarAI>();
        }
        _owner.target = target.transform;
        ai.maxSpeed = _owner.killModeSpeed;

    }

    public override void ExitState(MonsterAI _owner)
    {
       //Debug.Log("Exited Kill mode");
    }

    public override void UpdateState(MonsterAI _owner)
    {
        if (startedTimer)
        {
            if (_owner.GetFovDetection().IsInView())
            {
                startedTimer = false;
            }
            else if ((Time.unscaledTime - startTime) >= 3)
            {
                _owner.ChangeState(MonsterAI.MonsterState.Intimidate);
            }
        }
        if (!_owner.GetFovDetection().IsInView() && !startedTimer)
        {
            startTime = Time.unscaledTime;
            startedTimer = true;
        }
        _owner.target = target.transform;
    }
}
