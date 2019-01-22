using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Vector2Reference : BaseReference<Vector2Variable, Vector2>
{

    public Vector2 Normalized
    {
        get
        {
            return Value.normalized;
        }
    }
    
}