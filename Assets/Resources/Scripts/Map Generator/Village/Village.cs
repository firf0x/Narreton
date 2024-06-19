using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Village : MonoBehaviour, IInitialize {
    
    public Tilemap VillageTileMap;

    public List<TileBase> AvailableTiles = new List<TileBase>();
    public List<TileBase> VillagersTiles = new List<TileBase>();
    public TileBase PlayerTile;
    public TileBase ExitTile;
    public static Cell EntryCell;
    public void Initialize()
    {
        InitialiseMap();
    }
    private void OnDestroy() {
        CellList.Clear(CellList.villageCellList);
        EntryCell = null;
    }

    private void InitialiseMap()
    {
        CellList.SetSizeCellsVillage(VillageTileMap.size.x, VillageTileMap.size.y);
        TileMap.SetTileMapVillage(VillageTileMap);
        InvokeGenerateCells();
        SpawnPlayer();
        Debug.Log("Good");
    }

    private void InvokeGenerateCells()
    {
        for (int x = 0; x < CellList.villageCellList.GetLength(0); x++)
        {
            for (int y = 0; y < CellList.villageCellList.GetLength(1); y++)
            {
                CellList.villageCellList[x, y] = new Cell(new Vector2Int(x, y), AvailableTiles, VillageTileMap.GetTile(new Vector3Int(x, y, 0))); // Invoke Set Cell.
                if (VillagersTiles.Contains(VillageTileMap.GetTile(new Vector3Int(x, y, 0))))
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx == 0 && dy == 0) continue; // skip the current cell

                            int checkX = x + dx;
                            int checkY = y + dy;

                            if (checkX >= 0 && checkX < CellList.villageCellList.GetLength(0) &&
                                checkY >= 0 && checkY < CellList.villageCellList.GetLength(1))
                            {
                                if(CellList.villageCellList[checkX, checkY] != null)
                                {
                                    CellList.villageCellList[checkX, checkY].SetIsTalk();
                                }
                            }
                        }
                    }
                    Debug.Log("Клетки вокруг деревенщин установлены");
                }
                if (VillageTileMap.GetTile(new Vector3Int(x, y, 0)) == ExitTile)
                {
                    CellList.villageCellList[x, y].SetIsExitVillage();
                    Debug.Log($"{x} and {y}");
                }
            }
        }
    }

    private void SpawnPlayer()
    {
        CellList.villageCellList[49, 18].SetTile(TileMap.tileMapVillage, PlayerTile);
        EntryCell = CellList.villageCellList[49, 18];
        //Debug.Log(CellList.villageCellList[49, 18]);
    }
}