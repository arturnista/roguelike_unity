using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoadTilemap : MonoBehaviour
{
    
    public MapSaveData MapData;
    
    public void LoadData(Vector2Int basePosition)
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
                tilemap.SetTile((Vector3Int)basePosition + tile.WorldPosition, tile.Tile);
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
