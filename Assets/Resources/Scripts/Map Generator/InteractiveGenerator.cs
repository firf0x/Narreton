using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

namespace Assets.Resources.Scripts.MapGenerator{
    public class InteractiveGenerator {
        private static Cell[,] _aliveMap;
        private static List<Cell> _aliveCells;
        private static int _sizeHouse;
        public static void SetSizeHouse(int index) => _sizeHouse = index; 
        public static void SetMap(Cell[,] map) => _aliveMap = map; // Set alive map;
        public static void GenEntryAndExit(List<TileBase> list, ref Tilemap tilemap)
        {   
            _aliveCells = new List<Cell>();
            for (int x = 0; x < _aliveMap.GetLength(0); x++)
            {
                for (int y = 0; y < _aliveMap.GetLength(1); y++)
                {
                    if (_aliveMap[x, y].IsAlive)
                    {
                        _aliveCells.Add(_aliveMap[x, y]);
                    }
                }
            }

            if (list.Count >= 2)
            {
                for (int i = 0; i <= 1; i++)
                {
                    Cell randomCell = _aliveCells[Random.Range(0, _aliveCells.Count)];
                    randomCell.Tile = list[i];
                    randomCell.SetTile(tilemap);
                }
            }
            else
            {
                Debug.LogError("List must have at least two elements!");
            }
        }
        public static void GenHouseOnMap(List<TileBase> list, ref Tilemap tilemap)
        {
            if (list.Count > 0)
            {
                List<Cell> saveCell = new List<Cell>();
                for(int i = 0; i < _sizeHouse; i++)
                {
                    Cell randomCell = _aliveCells[Random.Range(0, _aliveCells.Count)];
                    for(int j = 0; j < saveCell.Count; j++)
                    {
                        if(saveCell.Contains(randomCell))
                        {
                            randomCell = _aliveCells[Random.Range(0, _aliveCells.Count)];
                        }
                        else
                        {
                            saveCell.Add(randomCell);
                        }
                    }
                    
                    randomCell.Tile = list[Random.Range(0, list.Count)];

                    randomCell.SetTile(tilemap);
                }
            }
            else
            {
                Debug.LogError("List must have at least zero elements!");
            }
        }
    }
}