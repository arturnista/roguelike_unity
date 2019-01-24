using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolderRegister : MonoBehaviour
{

    public DataHolder Holder;

    public T GetVariable<T>(DataName dataName) where T : BaseVariable
    {
        T variable = Holder.GetVariable<T>(gameObject.GetInstanceID(), dataName);
        return variable;
    }

}
