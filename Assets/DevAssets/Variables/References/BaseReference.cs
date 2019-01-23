using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class BaseReference<T, F> where T : BaseSimpleVariable<F>
{
    
    public enum VariableType
    {
        Constant,
        Variable,
        Instance
    }

    public VariableType Type = VariableType.Constant;
    public F ConstantValue;
    public T Variable;

    private T instanceVariable;
    public T InstanceVariable
    {
        set
        {
            instanceVariable = value;
        }
        get
        {
            return instanceVariable;
        }
    }

    public F Value
    {
        get
        {
            switch(Type)
            {

                case VariableType.Variable:
                    return Variable.Value;

                case VariableType.Instance:
                    return instanceVariable.Value;
                    
                default:
                    return ConstantValue;
            }
        }
        set
        {
            
            switch(Type)
            {

                case VariableType.Constant:
                    ConstantValue = value;
                    break;

                case VariableType.Variable:
                    Variable.Value = value;
                    break;

                case VariableType.Instance:
                    if(instanceVariable) instanceVariable.Value = value;
                    break;
                    
            }
        }
    }

    public void ResetValue() {
            
        switch(Type)
        {

            case VariableType.Variable:
                Variable.ResetValue();
                break;

            case VariableType.Instance:
                if(instanceVariable) instanceVariable.ResetValue();
                break;
                
        }

    }

    public static implicit operator bool(BaseReference<T, F> value)
    {
        return value != null || (value.Type == BaseReference<T, F>.VariableType.Instance && value.InstanceVariable);
    }
    
}