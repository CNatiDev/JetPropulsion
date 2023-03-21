using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventTriggerCollider : MonoBehaviour
{
    public UnityEvent @event;
    public string Tag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
            @event.Invoke();
    }
}
