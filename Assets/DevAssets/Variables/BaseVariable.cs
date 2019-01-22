using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVariable : ScriptableObject
{
    
#if UNITY_EDITOR
    [Multiline]
    public string Description;
#endif

}
