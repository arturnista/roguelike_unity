using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Holder/Create")]
public class DataHolder : ScriptableObject
{

    public List<DataHolderItem> Data;
    public Dictionary<DataName, DataHolderItem> DataDictonary;
    public Dictionary<int, Dictionary<DataName, BaseVariable>> InstanceData;

    void OnEnable()
    {

        if(Data != null)
        {
            InstanceData = new Dictionary<int, Dictionary<DataName, BaseVariable>>();

            DataDictonary = new Dictionary<DataName, DataHolderItem>();
            foreach (var item in Data)
            {
                DataDictonary.Add(item.Name, item);
            }
        }

    }

    public T GetVariable<T>(int id, DataName dataName) where T : BaseVariable
    {
        if(!DataDictonary.ContainsKey(dataName)) return null;

        Dictionary<DataName, BaseVariable> dictonary;
        if(!InstanceData.ContainsKey(id))
        {
            dictonary = new Dictionary<DataName, BaseVariable>();
            InstanceData.Add(id, dictonary);
        }
        else 
        {
            dictonary = InstanceData[id];
        }

        if(!dictonary.ContainsKey(dataName))
        {
            dictonary.Add(dataName, ScriptableObject.Instantiate(DataDictonary[dataName].Variable));
        }

        return (T)dictonary[dataName];

    }

}
