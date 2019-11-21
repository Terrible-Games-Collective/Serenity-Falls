using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

// This is a Scriptable object that will be used to signal gameObjects to update
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();
    // list of signal listener
    public void Raise()
    {
        for (int i = listeners.Count - 1; i>=0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }
    // adds the gameObject signal to that is to be listened to
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }
    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
