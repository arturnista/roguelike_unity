using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsSpreadVariable : MonoBehaviour
{

#region Variables
    [Header("Variables")]
    [SerializeField]
    public FloatVariable Health;
#endregion    
    
    void Awake()
    {
        Health = ScriptableObject.Instantiate(Health);

        Destructible destructible = GetComponent<Destructible>();
        destructible.Health.InstanceVariable = Health;
    }

}
