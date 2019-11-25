using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// got the idea from Mister Taft Creates
// its a signal system that is used to communicate between player and 
// its surrounding game objects
public class SignalListener : MonoBehaviour
{

    public Signal signal;
    public UnityEvent signalEvent;

    // signal that is a Scriptable Object that will tell the event if something needs to
    // be updated

        // invoke the event
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }
    private void OnEnable()
    {
        signal.RegisterListener(this);
    }
    private void OnDisable()
    {
        signal.DeRegisterListener(this);
    }
}
