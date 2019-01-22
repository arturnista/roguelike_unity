using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatRangeVariable", menuName = "Variables/Range Float")]
public class FloatRangeVariable : BaseSimpleRangeVariable<float>
{
    public override float Lerp(float perc) {
        return Mathf.Lerp(MinValue, MaxValue, perc);
    }
}
