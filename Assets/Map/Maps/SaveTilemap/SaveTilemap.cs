using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SaveTilemap : MonoBehaviour
{
    
    public MapSaveData SaveTo;

    public void SaveData()
    {
        
        SaveTo.layers.Clear();

        Tilemap[] allTilemaps = GetComponentsInChildren<Tilemap>();
        foreach(Tilemap tilemap in allTilemaps)
        {

            MapLayer layer = new MapLayer(tilemap.name, tilemap.origin, tilemap.size, tilemap.GetComponent<TilemapCollider2D>() != null);
            for (int x = 0; x < tilemap.size.x; x++)
            {
                for (int y = 0; y < tilemap.size.y; y++)
                {   
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);
                    if (tilemap.HasTile(tilePosition))
                    {
                        TileBase tile = tilemap.GetTile(tilePosition);
                        MapTile mapTile = new MapTile((Vector2Int) tilePosition, tile);
                        layer.Tiles.Add(mapTile);
                    }
                }
            }

            SaveTo.layers.Add(layer);
        }

        Debug.Log("Data saved!");
    }
}
