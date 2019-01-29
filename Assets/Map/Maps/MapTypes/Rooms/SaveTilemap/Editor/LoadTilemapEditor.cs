using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoadTilemap))]
public class LoadTilemapEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        LoadTilemap LoadTilemap = (LoadTilemap)target;
        if(GUILayout.Button("Load data"))
        {
            LoadTilemap.LoadData();
        }
        if(GUILayout.Button("Clear data"))
        {
            LoadTilemap.ClearData();
        }
    }

}
