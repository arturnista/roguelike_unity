using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName="Maps/Create Modular")]
public class MapModular : Map {

    public MapSaveData[] RoomsData;

    public override void Create(Transform parent)
    {

        base.Create(parent);

        CreateRoom(parent, Vector3.zero, 4);
        
    }

    void CreateRoom(Transform parent, Vector3 originPosition, int amount)
    {
        
        if(amount <= 0) return;

        GameObject roomInstance = new GameObject();
        LoadTilemap load = roomInstance.AddComponent<LoadTilemap>();
        MapSaveData data = RoomsData[Random.Range(0, RoomsData.Length)];
        roomInstance.name = data.name;
        load.MapData = data;
        load.ClearData();
        load.LoadData();

        Vector3 roomPosition = new Vector3(
            0f, 
            0f, 
            0f
        );
        roomInstance.transform.position = roomPosition;
        roomInstance.transform.parent = parent;

        for (int i = 0; i < amount; i++) CreateRoom(parent, roomPosition, amount - 1);

    }

}