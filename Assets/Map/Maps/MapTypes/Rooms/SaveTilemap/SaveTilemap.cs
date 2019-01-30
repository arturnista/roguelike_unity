using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SaveTilemap : MonoBehaviour
{
    
    public MapSaveData MapData;

    public void SaveData()
    {
        if(MapData.Layers == null) MapData.Layers = new List<MapLayer>();
        else MapData.Layers.Clear();

        Tilemap[] allTilemaps = GetComponentsInChildren<Tilemap>();
        foreach(Tilemap tilemap in allTilemaps)
        {
            
            TilemapRenderer tilemapRenderer = tilemap.GetComponent<TilemapRenderer>();
            MapLayer layer = new MapLayer(
                tilemap.name, 
                tilemap.origin, 
                tilemap.size, 
                tilemap.gameObject.layer, 
                tilemapRenderer.sortingLayerID, 
                tilemapRenderer.sortingOrder, 
                tilemap.GetComponent<TilemapCollider2D>() != null
            );
            
            BoundsInt bounds = tilemap.cellBounds;
            Debug.Log("size: " + bounds.size);
            Debug.Log("min: " + bounds.min);
            Debug.Log("max: " + bounds.max);
            Debug.Log("center: " + bounds.center);
            Debug.Log("position: " + bounds.position);
            Debug.Log("origin: " + tilemap.origin);
            Debug.Log("================");
            
            for (int x = bounds.min.x; x < bounds.max.x; x++)
            {
                for (int y = bounds.min.y; y < bounds.max.y; y++)
                {
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);
                    if (tilemap.HasTile(tilePosition))
                    {
                        TileBase tile = tilemap.GetTile(tilePosition);
                        Vector2Int tileSavePosition = new Vector2Int(x, y);

                        Debug.Log(layer.Name + " :: " + tile.name + " :: " + tileSavePosition.x + ", " + tileSavePosition.y + " :: " + x + ", " + y);
                        if(tileSavePosition.x > MapData.TopRight.x) MapData.TopRight.x = tileSavePosition.x;
                        if(tileSavePosition.y > MapData.TopRight.y) MapData.TopRight.y = tileSavePosition.y;

                        MapTile mapTile = new MapTile(tileSavePosition, tile);
                        layer.Tiles.Add(mapTile);

                    }
                }
            }        
            
            MapData.Origin = (Vector2Int)tilemap.origin;
            MapData.Center = new Vector2Int((int)bounds.center.x, (int)bounds.center.y);
            MapData.Layers.Add(layer);
            
        }

        Debug.Log("Data saved!");
    }

}
