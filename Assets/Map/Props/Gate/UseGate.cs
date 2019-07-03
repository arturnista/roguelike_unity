using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGate : Gate, IUsable
{

    protected override void Awake()
    {
        base.Awake();
    }

    public bool Use(Transform user)
    {
        Open();
        return true;
    }

}
