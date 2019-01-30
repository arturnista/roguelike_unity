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

        CreateRoom(parent, Vector2Int.zero, 3);
        
    }

    void CreateRoom(Transform parent, Vector2Int originPosition, int amount)
    {
        
        if(amount <= 0) return;

        LoadTilemap load = parent.gameObject.AddComponent<LoadTilemap>();
        MapSaveData data = RoomsData[Random.Range(0, RoomsData.Length)];
        parent.gameObject.name = data.name;
        load.MapData = data;
        load.LoadData(originPosition);

        Vector2Int roomPosition = new Vector2Int(
            originPosition.x + data.TopRight.x, 
            originPosition.y
        );

        for (int i = 0; i < amount; i++) CreateRoom(parent, roomPosition, amount - 1);

    }

}