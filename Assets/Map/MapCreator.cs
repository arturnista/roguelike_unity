using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapCreator : MonoBehaviour
{

    [SerializeField]
    private Map map;

    public Tile GroundTile;
    public Tile WallTile;

    private Tilemap groundTilemap;

    void Start()
    {
        // groundTilemap = transform.Find("Grid/Ground").GetComponent<Tilemap>();
        map.Create(transform);
        // FillMap();
    }

    Tile TypeToTile(MapTile.TileType type)
    {
        if(type == MapTile.TileType.Ground) return GroundTile;
        return WallTile;
    }

    void FillMap()
    {
        foreach(KeyValuePair<Vector2Int, MapTile> entry in map.Data)
        {
            groundTilemap.SetTile(entry.Value.WorldPosition, TypeToTile(entry.Value.Type));
        }
    }

}
