using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName="Maps/Create Automata")]
public class MapAutomata : Map {

    public int Height;
    public int Width;

    public override void Create(Transform parent)
    {
        base.Create(parent);

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                MapTile tile = new MapTile(new Vector2Int(x, y), MapTile.TileType.Ground);
                data.Add(tile.Position, tile);
            }
        }

        Randomize();
        SingleCycle();
        SingleCycle();
    }

    void Randomize()
    {
        float perc = 0.45f;
        foreach(KeyValuePair<Vector2Int, MapTile> entry in data)
        {
            if(Random.value > perc) entry.Value.Type = MapTile.TileType.Ground;
            else entry.Value.Type = MapTile.TileType.Wall;
        }
    }

    void SingleCycle()
    {
        foreach(KeyValuePair<Vector2Int, MapTile> entry in data)
        {
            int neighborsWalls = GetNeighborsWall(entry.Value);
            PrepareTile(entry.Value, neighborsWalls);
        }

        foreach(KeyValuePair<Vector2Int, MapTile> entry in data)
        {
            entry.Value.Execute();
        }
    }

    void PrepareTile(MapTile tile, int neighborsWalls)
    {
        if (tile.Type == MapTile.TileType.Wall) { // Wall
            if (neighborsWalls < 3) {
                tile.Prepare(MapTile.TileType.Ground); // Become floor
            }
        } else { // Floor
            if (neighborsWalls > 4) {
                tile.Prepare(MapTile.TileType.Wall); // Become wall
            }
        }
    }

    int GetNeighborsWall(MapTile tile)
    {
        int walls = 0;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if(x == 0 && y == 0) continue;

                int xPos = tile.Position.x + x;
                if(xPos >= Width) xPos = 0;
                else if(xPos < 0) xPos = Width - 1;

                int yPos = tile.Position.y + y;
                if(yPos >= Height) yPos = 0;
                else if(yPos < 0) yPos = Height - 1;

                Vector2Int pos = new Vector2Int(xPos, yPos);
                if(!data.ContainsKey(pos)) continue;

                MapTile checkTile = data[pos];
                if(checkTile.Type == MapTile.TileType.Wall) walls++;
            }

        }

        return walls;
    }

}