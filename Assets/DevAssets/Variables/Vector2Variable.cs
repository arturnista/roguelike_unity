using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector2Variable", menuName = "Variables/Vector2")]
public class Vector2Variable : BaseSimpleVariable<Vector2>
{

    public Vector2 Normalized
    {
        get
        {
            return Value.normalized;
        }
    }

}
