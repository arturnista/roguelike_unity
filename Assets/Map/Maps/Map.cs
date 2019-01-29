using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : ScriptableObject {

    protected Dictionary<Vector2Int, MapTile> data;
    public Dictionary<Vector2Int, MapTile> Data {
        get { return data; }
    }

    public virtual void Create(Transform parent)
    {
        if(data == null) data = new Dictionary<Vector2Int, MapTile>();
        else data.Clear();
    }

}