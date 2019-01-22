using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class FloatRangeReference : System.Object
{
    
    public enum VariableType
    {
        Constant,
        Variable,
        Instance
    }

    public VariableType Type = VariableType.Constant;
    public float ConstantMinValue;
    public float ConstantMaxValue;
    public FloatRangeVariable Variable;

    private FloatRangeVariable InstanceVariable = null;

    public float MinValue
    {
        get
        {
            switch(Type) {
                case VariableType.Constant:
                    return ConstantMinValue;

                case VariableType.Variable:
                    return Variable.MinValue;

                case VariableType.Instance:
                    if(InstanceVariable == null) {
                        InstanceVariable = ScriptableObject.Instantiate(Variable);
                    }
                    return InstanceVariable.MinValue;
                default:
                    return 0f;
            }
        }
        set
        {
            
            switch(Type) {

                case VariableType.Variable:
                    Variable.MinValue = value;
                    break;

                case VariableType.Instance:
                    if(InstanceVariable == null) {
                        InstanceVariable = ScriptableObject.Instantiate(Variable);
                    }
                    InstanceVariable.MinValue = value;
                    break;
                    
            }
        }
    }

    public float MaxValue
    {
        get
        {
            switch(Type) {
                case VariableType.Constant:
                    return ConstantMaxValue;

                case VariableType.Variable:
                    return Variable.MaxValue;

                case VariableType.Instance:
                    if(InstanceVariable == null) {
                        InstanceVariable = ScriptableObject.Instantiate(Variable);
                    }
                    return InstanceVariable.MaxValue;
                default:
                    return 0f;
            }
        }
        set
        {
            
            switch(Type) {

                case VariableType.Variable:
                    Variable.MaxValue = value;
                    break;

                case VariableType.Instance:
                    if(InstanceVariable == null) {
                        InstanceVariable = ScriptableObject.Instantiate(Variable);
                    }
                    InstanceVariable.MaxValue = value;
                    break;
                    
            }
        }
    }

}