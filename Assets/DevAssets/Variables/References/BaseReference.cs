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
    }

    public F Value
    {
        get
        {
            switch(Type) {

                case VariableType.Variable:
                    return Variable.Value;

                case VariableType.Instance:
                    if(instanceVariable == null) {
                        instanceVariable = ScriptableObject.Instantiate(Variable);
                    }
                    return instanceVariable.Value;
                default:
                    return ConstantValue;
            }
        }
        set
        {
            
            switch(Type) {

                case VariableType.Variable:
                    Variable.Value = value;
                    break;

                case VariableType.Instance:
                    if(instanceVariable == null) {
                        instanceVariable = ScriptableObject.Instantiate(Variable);
                    }
                    instanceVariable.Value = value;
                    break;
                    
            }
        }
    }

}