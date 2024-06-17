using System;
using UnityEngine;

public static class CellList {
    public static Cell[,] cellList;
    public static Cell[,] villageCellList;
    
    //-----------------------------------------------------------------------------------------------------------
    // Main (Cave)
    public static void SetSizeCells(bool[,] map)
    {
        cellList = new Cell[map.GetLength(0), map.GetLength(1)];  
    } 
    public static void SetSizeCells(Vector2Int size) 
    {
        cellList = new Cell[size.x, size.y];
    }
    public static void SetSizeCells(int minValue, int maxValue)
    {
        cellList = new Cell[minValue, maxValue];
    }
    
    
    //-----------------------------------------------------------------------------------------------------------
    // Village
    public static void SetSizeCellsVillage(bool[,] map)
    {
        villageCellList = new Cell[map.GetLength(0), map.GetLength(1)];
    }
    public static void SetSizeCellsVillage(Vector2Int size)
    {
        villageCellList = new Cell[size.x, size.y];
    }
    public static void SetSizeCellsVillage(int minValue, int maxValue)
    {
        villageCellList = new Cell[minValue, maxValue];
    }


    //-----------------------------------------------------------------------------------------------------------
    // Other
    public static void GetCellOfCoordinate(Vector2Int position, Cell[,] aliveMap, out Cell cell) => cell = aliveMap[position.x, position.y]; 
    public static void Clear(Cell[,] massive) => Array.Clear(massive, 0, cellList.Length);
        
}