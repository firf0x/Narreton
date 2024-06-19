using UnityEngine;
using UnityEngine.Tilemaps;
public interface ISetTile {
    void SetTile(Tilemap tilemap);
    void SetTile(Tilemap tilemap, TileBase tile);
}