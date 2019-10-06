using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineTools
{

    public class StateMachine<T>
    {
        public State<T> currentState { get; private set; }
        public T Owner;

        public StateMachine(T _o)
        {
            Owner = _o;
            currentState = null;
        }

        public void ChangeState(State<T> _newState)
        {
            if(currentState != null)
            {
                currentState.ExitState(Owner);
            }
            currentState = _newState;
            currentState.EnterState(Owner);

        }

        public void Update()
        {
            if (currentState != null)
                currentState.UpdateState(Owner);
        }
    }

    public abstract class State<T>
    {
        //Put things here if you want it to happen once when you enter the state
        public abstract void EnterState(T _owner);
        //Put things here if you want it to happen once when you exit the state
        public abstract void ExitState(T _owner);
        //Will Be called every frame like update
        public abstract void UpdateState(T _owner);
    }
}
