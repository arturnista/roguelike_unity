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

            // for (int x = 0; x < tilemap.size.x; x++)
            // {
            //     for (int y = 0; y < tilemap.size.y; y++)
            //     {   
            //         Vector3Int tilePosition = new Vector3Int(x, y, 0);
            //         if (tilemap.HasTile(tilePosition))
            //         {
            //             TileBase tile = tilemap.GetTile(tilePosition);
            //             MapTile mapTile = new MapTile((Vector2Int) tilePosition, tile);
            //             layer.Tiles.Add(mapTile);
            //         }
            //     }
            // }

            BoundsInt bounds = tilemap.cellBounds;
            TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

            for (int x = 0; x < bounds.size.x; x++) {
                for (int y = 0; y < bounds.size.y; y++) {
                    TileBase tile = allTiles[x + y * bounds.size.x];
                    if (tile != null) {
                        
                        Vector2Int tilePosition = new Vector2Int(x, y);
                        MapTile mapTile = new MapTile(tilePosition, tile);
                        layer.Tiles.Add(mapTile);

                    }
                }
            }        

            MapData.Layers.Add(layer);
        }

        Debug.Log("Data saved!");
    }

    public void LoadData()
    {
        // Get or Create the GRID
        Grid grid = GetComponent<Grid>();
        if(grid == null) grid = gameObject.AddComponent<Grid>();

        foreach(MapLayer layer in MapData.Layers)
        {

            // Get or create the child for the layer
            Transform childTilemap = transform.Find(layer.Name);
            if(childTilemap == null)
            {
                GameObject tilemapGO = new GameObject(layer.Name);
                tilemapGO.transform.parent = grid.transform;
                childTilemap = tilemapGO.transform;

            }

            // Initialize its position
            childTilemap.transform.localPosition = Vector3.zero;

            // Get or create the tilemaps
            Tilemap tilemap = childTilemap.GetComponent<Tilemap>();
            if(tilemap == null) tilemap = childTilemap.gameObject.AddComponent<Tilemap>();

            TilemapRenderer tilemapRenderer = childTilemap.GetComponent<TilemapRenderer>();
            if(tilemapRenderer == null) tilemapRenderer = childTilemap.gameObject.AddComponent<TilemapRenderer>();

            // Set the values
            childTilemap.gameObject.layer = layer.Layer;

            tilemap.size = layer.Size;
            tilemap.origin = layer.Origin;

            tilemapRenderer.sortingLayerID = layer.SortingLayerID;
            tilemapRenderer.sortingOrder = layer.OrderInLayer;

            TilemapCollider2D collider = childTilemap.GetComponent<TilemapCollider2D>();
            if(layer.HasCollider && collider == null)
            {
                childTilemap.gameObject.AddComponent<TilemapCollider2D>();
            }
            else if(!layer.HasCollider && collider != null)
            {
                DestroyImmediate(collider);
            }

            // Set the tiles
            foreach (MapTile tile in layer.Tiles)
            {
                tilemap.SetTile(tile.WorldPosition, tile.Tile);
            }
        }

        Debug.Log("Data Loaded!");
    }

    public void ClearData()
    {

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);

            TilemapCollider2D tilemapCollider2D = child.GetComponent<TilemapCollider2D>();
            Tilemap tilemap = child.GetComponent<Tilemap>();
            TilemapRenderer tilemapRenderer = child.GetComponent<TilemapRenderer>();

            tilemap.ClearAllTiles();

            if(tilemapCollider2D != null) DestroyImmediate(tilemapCollider2D);
            DestroyImmediate(tilemapRenderer);
            DestroyImmediate(tilemap);
            DestroyImmediate(child.gameObject);
        }

        Debug.Log("Data clear!");
    }
}
