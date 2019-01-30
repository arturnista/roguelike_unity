using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Events/Simple")]
public class BaseEvent : ScriptableObject
{

    public delegate void EventFunction(BaseEvent eventData);
    public EventFunction Actions;

    public void Dispatch()
    {
        Actions(this);
    }

}
