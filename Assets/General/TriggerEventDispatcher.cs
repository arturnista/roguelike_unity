using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventDispatcher : MonoBehaviour
{

    public TriggerEvent Event;

    void OnTriggerEnter2D(Collider2D coll)
    {
        Event.collider = coll;
        Event.Dispatch();
    }

}
