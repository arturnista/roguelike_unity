using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedSwitch : Switch
{
    public float Time;
    public int ActionToTime;

    protected override void DispatchAction(int index)
    {
        base.DispatchAction(index);
        if ( ActionToTime == index ) StartCoroutine(TimedDispatch());
    }

    IEnumerator TimedDispatch()
    {
        yield return new WaitForSeconds(Time);
        DispatchNextAction();
    }

}
