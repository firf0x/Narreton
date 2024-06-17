using UnityEngine;
using UnityEngine.Tilemaps;
public static class TileMap {
    public static Tilemap tileMap {get; private set;}
    public static Tilemap tileMapVillage {get; private set;}
    public static void SetTileMap(Tilemap tilemap) => tileMap = tilemap;
    public static void SetTileMapVillage(Tilemap tilemap) => tileMapVillage = tilemap;
}