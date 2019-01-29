using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveTilemap))]
public class SaveTilemapDrawer : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        SaveTilemap saveTilemap = (SaveTilemap)target;
        if(GUILayout.Button("Save tilemap data"))
        {
            saveTilemap.SaveData();
        }
    }

}
