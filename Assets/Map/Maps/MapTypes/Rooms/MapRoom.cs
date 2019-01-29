using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapRoom : MonoBehaviour
{

    private Vector2Int size;
    public Vector2Int Size { get { return size; } }

    private Vector2Int origin;
    public Vector2Int Origin { get { return origin; } }

    public void Construct()
    {
        Tilemap[] tilemaps = GetComponentsInChildren<Tilemap>();
        foreach (Tilemap tilemap in tilemaps)
        {
            Debug.Log("size: " + tilemap.size);
            Debug.Log("origin: " + tilemap.origin);
            BoundsInt bounds = tilemap.cellBounds;
            // Debug.Log(bounds.size);
            size = (Vector2Int) tilemap.size;
            origin = (Vector2Int) tilemap.origin;
            // TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

            // for (int x = 0; x < bounds.size.x; x++) {
            //     for (int y = 0; y < bounds.size.y; y++) {
            //         TileBase tile = allTiles[x + y * bounds.size.x];
            //         if (tile != null) {

            //         }
            //     }
            // }    

        }
    }

}
