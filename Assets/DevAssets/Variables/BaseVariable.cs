using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVariable : ScriptableObject
{
    
#if UNITY_EDITOR
    [TextArea]
    public string Description;
#endif

}
