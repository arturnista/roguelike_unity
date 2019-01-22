using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSimpleVariable<T> : BaseVariable
{

    [Space]
    public T DefaultValue;
    
    [ReadOnly]
    [SerializeField]
    private T value;
    
    public virtual T Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public override string ToString() {
        return this.name + ": " + Value;
    }
    
    protected virtual void OnEnable()
    {
        ResetValue();
    }

    public virtual void ResetValue() {
        value = DefaultValue;
    }

}
