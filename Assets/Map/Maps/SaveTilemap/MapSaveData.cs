using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName="Maps/Create save data")]
public class MapSaveData : ScriptableObject {

    public List<MapLayer> Layers;

}