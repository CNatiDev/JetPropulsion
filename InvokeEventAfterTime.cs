using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InvokeEventAfterTime : MonoBehaviour
{
    public float Time_A;
    public UnityEvent Event;
    private IEnumerator coroutine;
    public void Invoke_Event()
    {
        coroutine = WaitAndExecute(Time_A);
        StartCoroutine(coroutine);
    }
    IEnumerator WaitAndExecute(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        Event.Invoke();
    }

}
