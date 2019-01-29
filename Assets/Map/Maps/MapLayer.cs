using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class MapLayer {
    
    [SerializeField]
    private string name;
    public string Name { get { return name; } }
    [SerializeField]
    private bool hasCollider;
    public bool HasCollider { get { return hasCollider; } }
    [SerializeField]
    private Vector3Int origin;
    public Vector3Int Origin { get { return origin; } }
    [SerializeField]
    private Vector3Int size;
    public Vector3Int Size { get { return size; } }
    [SerializeField]
    private int layer;
    public int Layer { get { return layer; } }
    [SerializeField]
    private int sortingLayerID;
    public int SortingLayerID { get { return sortingLayerID; } }
    [SerializeField]
    private int orderInLayer;
    public int OrderInLayer { get { return orderInLayer; } }
    [SerializeField]
    private List<MapTile> tiles = new List<MapTile>();
    public List<MapTile> Tiles { get { return tiles; } set { tiles = value; } }

    public MapLayer(string _name, Vector3Int _origin, Vector3Int _size, int _layer, int _sortingLayerID, int _orderInLayer, bool _hasCollider)
    {
        name = _name;
        origin = _origin;
        size = _size;
        layer = _layer;
        sortingLayerID = _sortingLayerID;
        orderInLayer = _orderInLayer;
        hasCollider = _hasCollider;
    }

}