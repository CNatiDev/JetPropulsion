using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InvokeEvents : MonoBehaviour
{
    public UnityEvent Event;
    public void Invoke_Event_1()
    {
        Event.Invoke();
    }
}
