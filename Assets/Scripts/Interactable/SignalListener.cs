using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// got this from Mister Taft Creates
public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent;
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
