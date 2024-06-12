using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Cell {
    public Vector2Int Coordinates {get; private set;}
    public bool IsAlive {get; set;}
    public TileBase Tile {get; set;}

    public Cell(Vector2Int coordinates, bool isAlive, List<TileBase> tile)
    {
        this.Coordinates = coordinates;
        this.IsAlive = isAlive;
        if(isAlive != true)
        {
            this.Tile = tile[0];
        }
        else
        {
            this.Tile = tile[1];
        }
    }

    // set dinamic and static Tiles
    public void SetTile(Tilemap tilemap)
    {
        tilemap.SetTile(new Vector3Int(Coordinates.x, Coordinates.y, 0), Tile);
    }
    public void SetTile(Tilemap tilemap, TileBase tile)
    {
        tilemap.SetTile(new Vector3Int(Coordinates.x, Coordinates.y, 0), tile);
    }
}