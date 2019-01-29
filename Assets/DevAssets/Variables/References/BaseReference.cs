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

    public DataName HolderDataName;
    public DataHolderRegister HolderRegister;

    private T instanceVariable;
    public T InstanceVariable
    {
        set
        {
            instanceVariable = value;
        }
        get
        {
            if(instanceVariable == null) {
                instanceVariable = HolderRegister.GetVariable<T>(HolderDataName);
            }
            return instanceVariable;
        }
    }

    public BaseSimpleVariable<F>.OnChangeValueAction OnChangeValue {
        get
        {
            switch(Type)
            {

                case VariableType.Variable:
                    return Variable.OnChangeValue;

                case VariableType.Instance:
                    if(InstanceVariable) return InstanceVariable.OnChangeValue;
                    return null;
                    
                default:
                    return null;
            }
        }
        set
        {
            switch(Type)
            {

                case VariableType.Variable:
                    Variable.OnChangeValue = value;
                    break;

                case VariableType.Instance:
                    if(InstanceVariable) InstanceVariable.OnChangeValue = value;
                    break;

                default:
                    Debug.LogWarning("OnChangeValue not set because of type " + Type);
                    break;
            }
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
                    return InstanceVariable.Value;
                    
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
                    if(InstanceVariable) InstanceVariable.Value = value;
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