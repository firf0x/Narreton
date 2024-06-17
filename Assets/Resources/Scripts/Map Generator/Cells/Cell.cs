using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Cell : ISetTile{
    public Vector2Int Coordinates {get; private set;}
    public bool IsAlive {get; set;}
    public bool IsVillage {get; private set;}
    public bool IsExit {get; private set;}
    public bool IsTalk {get; private set;}
    public TileBase Tile {get; set;}

    //-----------------------------------------------------------------------------------------------------------
    // Cell
    public Cell(Vector2Int coordinates, List<TileBase> tiles = null, TileBase tile = null, bool isAlive = false)
    {
        this.Coordinates = coordinates;
        this.IsAlive = isAlive;
        if(isAlive != true)
            this.Tile = tiles[1];
        else
            this.Tile = tiles[0];

        if(tile != null)
        {
            if(tiles.Contains(tile))
            {
                this.IsAlive = true;
                this.Tile = tile;
            }
            else
            {
                this.IsAlive = false;
                this.Tile = tile;
            }
        }
        this.IsVillage = false;
        this.IsExit = false;
        this.IsTalk = false;
    }

    // Setting the index whether this cell is something
    public void SetIsVillage() => this.IsVillage = true;
    public void SetIsExit() => this.IsExit = true;
    public void SetIsTalk() => this.IsTalk = true;

    // set dinamic and static Tile
    public void SetTile(Tilemap tilemap) => tilemap.SetTile(new Vector3Int(Coordinates.x, Coordinates.y, 0), Tile);
    public void SetTile(Tilemap tilemap, TileBase tile) => tilemap.SetTile(new Vector3Int(Coordinates.x, Coordinates.y, 0), tile);
}