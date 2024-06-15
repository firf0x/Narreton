using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

namespace Assets.Resources.Scripts.MapGenerator{
    public class InteractiveGenerator {
        private static Cell[,] _aliveMap;
        public static List<Cell> aliveCells;
        public static Cell EntryCell;
        private static int _sizeHouse;
        public static void SetSizeHouse(int index) => _sizeHouse = index; 
        public static void SetMap(Cell[,] map) => _aliveMap = map; // Set alive map;
        
        ///<summary>
        /// Generate Entry and Exit on map.
        ///</summary>
        public static void GenEntryAndExit(List<TileBase> list)
        {   
            Debug.Log("начало генерации Входа и выхода"); 
            if (list.Count >= 2)
            {
                for (int i = 0; i <= 1; i++)
                {
                    Cell randomCell = aliveCells[UnityEngine.Random.Range(0, aliveCells.Count)];
                    randomCell.Tile = list[i];
                    if(i == 0)
                        EntryCell = randomCell;

                    // set that this is a Entry
                    /*
                        It doesn't return false!!!!!
                    */

                    randomCell.SetIsExit(); 
                    
                    randomCell.SetTile(); // Set Default Tile
                }
            }
            else
            {
                Debug.LogError("List must have at least two elements!");
            }
            Debug.Log("конец генерации Входа и выхода"); 
        }

        public static void GenAliveCells()
        {
            aliveCells = new List<Cell>();
            for (int x = 0; x < _aliveMap.GetLength(0); x++)
            {
                for (int y = 0; y < _aliveMap.GetLength(1); y++)
                {
                    if (_aliveMap[x, y].IsAlive)
                    {
                        aliveCells.Add(_aliveMap[x, y]);
                    }
                }
            }
        }

        ///<summary>
        /// Generate city, village, lonely house.
        ///</summary>
        public static void GenHouseOnMap(List<TileBase> list)
        {
            Debug.Log("Начало генерации деревень");
            List<Cell> saveCell = new List<Cell>();
 
            if (list.Count > 0)
            {
                for(int i = 0; i < _sizeHouse; i++)
                {
                    Cell randomCell = aliveCells[UnityEngine.Random.Range(0, aliveCells.Count)];
                    
                    if(saveCell.Contains(randomCell))
                    {
                        randomCell = aliveCells[UnityEngine.Random.Range(0, aliveCells.Count)];
                    }
                    else
                    {
                        saveCell.Add(randomCell);
                        
                        randomCell.Tile = list[UnityEngine.Random.Range(0, list.Count)];

                        // Set that this is a village
                        /*
                            It doesn't return false!!!!!
                        */
                        randomCell.SetIsVillage(); 


                        randomCell.SetTile(); // Set Default Tile
                    }
                }
            }
            else
            {
                Debug.LogError("List must have at least zero elements!");
            }
            Debug.Log("Конец генерации деревень"); 
            saveCell.Clear();
        }

        public static void ClearMap()
        {
            Array.Clear(_aliveMap, 0, _aliveMap.Length);
            aliveCells.Clear();
        }
    }
}