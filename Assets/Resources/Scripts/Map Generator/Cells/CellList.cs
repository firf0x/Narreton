using UnityEngine;

public static class CellList {
    public static Cell[,] cellList;
    public static void GenerateCells(bool[,] map) => cellList = new Cell[map.GetLength(0), map.GetLength(1)];
    public static void GetCellOfCoordinate(int x, int y, out Cell cell) => cell = cellList[x, y]; 
}