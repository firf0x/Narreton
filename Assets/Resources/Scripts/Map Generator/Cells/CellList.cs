using UnityEngine;

public static class CellList {
    public static Cell[,] cellList;
    public static void GenerateCells(bool[,] map) => cellList = new Cell[map.GetLength(0), map.GetLength(1)];
}