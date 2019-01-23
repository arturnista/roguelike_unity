using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSimpleVariable<T> : BaseVariable
{

    [Space]
    public T DefaultValue;
    public bool ResetOnPlay = true;
    
    [Space]
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
        if(ResetOnPlay) ResetValue();
    }

    public virtual void ResetValue() {
        value = DefaultValue;
    }

    public static implicit operator bool(BaseSimpleVariable<T> value)
    {
        return value != null;
    }

}
