using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSimpleRangeVariable<T> : BaseSimpleVariable<T>
{

    [Space]
    public T MinDefaultValue;
    public T MaxDefaultValue;
 
    [ReadOnlyAttribute]
    private T minValue;
    [ReadOnlyAttribute]
    private T maxValue;
    
    public T MinValue
    {
        get { return minValue; }
        set { this.minValue = value; }
    }
    
    public T MaxValue
    {
        get { return maxValue; }
        set { this.maxValue = value; }
    }

    public abstract T Lerp(float perc);

    public override string ToString() {
        return this.name + ": " + MinValue + " to " + MaxValue;
    }

    public override void ResetValue() {
        minValue = MinDefaultValue;
        maxValue = MaxDefaultValue;
    }

}
