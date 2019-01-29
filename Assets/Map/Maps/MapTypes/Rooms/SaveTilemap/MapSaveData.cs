using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName="Maps/Create save data")]
public class MapSaveData : ScriptableObject {

    public Vector2Int TopRight;
    public Vector2Int Origin;
    public Vector2Int Center;

    public List<MapLayer> Layers;

}