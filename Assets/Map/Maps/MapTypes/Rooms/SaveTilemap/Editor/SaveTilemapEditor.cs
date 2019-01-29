using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveTilemap))]
public class SaveTilemapEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        SaveTilemap saveTilemap = (SaveTilemap)target;
        if(GUILayout.Button("Save data"))
        {
            saveTilemap.SaveData();
        }
    }

}
