using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class MapTile {
    
    public enum TileType
    {
        Ground,
        Wall
    }


    private TileType type;
    [SerializeField]
    private TileBase tile;
    public TileBase Tile { get { return tile; } }
    [SerializeField]
    private Vector2Int position;

    private TileType nextType;
    
    public TileType Type { get { return type; } set { type = value; } }
    public Vector2Int Position { get { return position; } }
    public Vector3Int WorldPosition { get { return (Vector3Int)position; } }

    public MapTile(Vector2Int _position, TileType _type)
    {
        position = _position;
        type = _type;
    }

    public MapTile(Vector2Int _position, TileBase _tile)
    {
        position = _position;
        tile = _tile;
    }

    public void Prepare(TileType type)
    {
        nextType = type;
    }

    public void Execute()
    {
        type = nextType;
    }

}