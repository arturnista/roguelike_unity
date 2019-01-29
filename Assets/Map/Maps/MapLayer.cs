using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class MapLayer {
    
    [SerializeField]
    private string name;
    [SerializeField]
    private bool hasCollider;
    [SerializeField]
    private Vector3Int origin;
    [SerializeField]
    private Vector3Int size;
    [SerializeField]
    private List<MapTile> tiles = new List<MapTile>();
    public List<MapTile> Tiles { get { return tiles; } set { tiles = value; } }

    public MapLayer(string _name, Vector3Int _origin, Vector3Int _size, bool _hasCollider)
    {
        name = _name;
        origin = _origin;
        size = _size;
        hasCollider = _hasCollider;
    }

}