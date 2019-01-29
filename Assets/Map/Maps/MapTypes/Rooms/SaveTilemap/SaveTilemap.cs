using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SaveTilemap : MonoBehaviour
{
    
    public MapSaveData MapData;

    public void SaveData()
    {
        
        MapData.Layers.Clear();

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
            Debug.Log(bounds.size);
            Debug.Log(bounds.min);
            Debug.Log(bounds.max);
            Debug.Log(bounds.center);
            Debug.Log(bounds.position);
            Debug.Log("================");
            
            TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

            for (int x = 0; x < bounds.size.x; x++) {
                for (int y = 0; y < bounds.size.y; y++) {
                    TileBase tile = allTiles[x + y * bounds.size.x];
                    if (tile != null) {

                        // int xTile = x + bounds.max.x - Mathf.Abs( bounds.min.x );
                        // int yTile = y + bounds.max.y - Mathf.Abs( bounds.min.y );
                        int xTile = (int)bounds.center.x + x;
                        int yTile = (int)bounds.center.y + y;
                        Vector2Int tilePosition = new Vector2Int(xTile, yTile);

                        Debug.Log(layer.Name + " :: " + tile.name + " :: " + tilePosition.x + ", " + tilePosition.y + " :: " + x + ", " + y);
                        if(tilePosition.x > MapData.TopRight.x) MapData.TopRight.x = tilePosition.x;
                        if(tilePosition.y > MapData.TopRight.y) MapData.TopRight.y = tilePosition.y;

                        MapTile mapTile = new MapTile(tilePosition, tile);
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
