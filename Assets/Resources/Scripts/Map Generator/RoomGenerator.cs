using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
namespace Assets.Resources.Scripts.MapGenerator
{
    public class RoomGenerator : MonoBehaviour
    {
        public Tilemap tileMap;
        public TileBase Tile_1; // alive tile
        public TileBase Tile_2; // dead tile
        public Vector2 Size;
        [Range(0, 1)]
        public float chanceToStartAlive;
        public int deathLimit;
        public int birthLimit;
        public int numberOfSteps;
        private bool[,] _map;
        public int RemoveEnds;
        public Vector2Int startPoint; // стартовая точка
        public Vector2Int endPoint; // конечная точка

        private void Awake()
        {
            _map = new bool[(int)Size.x, (int)Size.y];

            InitialiseMap(_map);

            for (int i = 0; i < RemoveEnds; i++)
            {
                GenerateTilemap();
            }

            // поиск пути от startPoint до endPoint
            bool pathFound = FindPath(_map, startPoint, endPoint);
            while (true)
            {
                if (!pathFound)
                {
                    // если путь не найден, перегенерируем карту
                    InitialiseMap(_map);
                    GenerateTilemap();
                    pathFound = FindPath(_map, startPoint, endPoint);
                    Debug.Log("путь не найден, перегенерируем карту");
                }
                if (pathFound)
                {
                    //ConnectCaves(_map, startPoint, endPoint); // добавляем соединение ближайших пещер
                    
                    // если путь найден, удалим тупиковые пещеры с помощью алгоритма Wave
                    RemoveDeadEndsWave(_map, startPoint, endPoint);
                    Debug.Log("путь найден");
                    break;
                }                
            }
        }
        private void ConnectCaves(bool[,] map, Vector2Int startPoint, Vector2Int endPoint)
        {
            // Создаем список ближайших пещер к активным
            List<Vector2Int> nearbyCaves = new List<Vector2Int>();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] && IsNearActiveCell(map, x, y, startPoint, endPoint))
                    {
                        nearbyCaves.Add(new Vector2Int(x, y));
                    }
                }
            }
            // Соединяем ближайшие пещеры с активной клеткой
            foreach (Vector2Int cave in nearbyCaves)
            {
                if (FindPath(map, cave, startPoint))
                {
                    ConnectCells(map, cave, startPoint);
                }
            }
        }
        private bool IsNearActiveCell(bool[,] map, int x, int y, Vector2Int startPoint, Vector2Int endPoint)
        {
            // Проверяем, находится ли клетка в радиусе 2 клеток от активной клетки
            int distanceX = Math.Abs(x - startPoint.x);
            int distanceY = Math.Abs(y - startPoint.y);
            
            if (distanceX <= 2 && distanceY <= 2)
            {
                return true;
            }

            distanceX = Math.Abs(x - endPoint.x);
            distanceY = Math.Abs(y - endPoint.y);

            if (distanceX <= 2 && distanceY <= 2)
            {
                return true;
            }
            return false;
        }

        private void ConnectCells(bool[,] map, Vector2Int start, Vector2Int end)
        {
            // Найдем путь от start до end
            bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)];

            FindPathRecursive(map, visited, start.x, start.y, end.x, end.y);

            // Установим клетки на пути в значение true
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (visited[x, y])
                    {
                        map[x, y] = true;
                    }
                }
            }
        }
        //private void Update() {
            //GenerateTilemap();
            //RemoveDeadEnds(_map);
            //RemoveUnconnectedCaves(_map);
        //}
        private void InitialiseMap(bool[,] map)
        {
            var random = new System.Random();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (random.NextDouble() < chanceToStartAlive)
                    {
                        map[x, y] = true; // alive
                    }
                    else
                    {
                        map[x, y] = false; // dead
                    }
                }
            }
        }

        private void GenerateTilemap()
        {
            for (int i = 0; i < numberOfSteps; i++)
            {
                _map = Step(_map);
            }

            for (int x = 0; x < _map.GetLength(0); x++)
            {
                for (int y = 0; y < _map.GetLength(1); y++)
                {
                    if (_map[x, y])
                    {
                        tileMap.SetTile(new Vector3Int(x, y, 0), Tile_1); // set alive tile
                    }
                    else
                    {
                        tileMap.SetTile(new Vector3Int(x, y, 0), Tile_2); // set dead tile
                    }
                }
            }
        }

        private bool[,] Step(bool[,] oldMap)
        {
            bool[,] newMap = new bool[oldMap.GetLength(0), oldMap.GetLength(1)];

            for (int x = 0; x < oldMap.GetLength(0); x++)
            {
                for (int y = 0; y < oldMap.GetLength(1); y++)
                {
                    int neighbours = CountAliveNeighbours(oldMap, x, y);
                    if (oldMap[x, y])
                    {
                        if (neighbours < deathLimit)
                        {
                            newMap[x, y] = false;
                        }
                        else
                        {
                            newMap[x, y] = true;
                        }
                    }
                    else
                    {
                        if (neighbours > birthLimit)
                        {
                            newMap[x, y] = true;
                        }
                        else
                        {
                            newMap[x, y] = false;
                        }
                    }
                }
            }
            return newMap;
        }

        private bool FindPath(bool[,] map, Vector2Int start, Vector2Int end)
        {
            bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)];
            return FindPathRecursive(map, visited, start.x, start.y, end.x, end.y);
        }
        private bool FindPathRecursive(bool[,] map, bool[,] visited, int x, int y, int targetX, int targetY)
        {
            if (x == targetX && y == targetY)
            {
                return true;
            }

            if (x < 0 || y < 0 || x >= map.GetLength(0) || y >= map.GetLength(1) ||!map[x, y] || visited[x, y])
            {
                return false;
            }

            visited[x, y] = true;

            if (FindPathRecursive(map, visited, x - 1, y, targetX, targetY) ||
                FindPathRecursive(map, visited, x + 1, y, targetX, targetY) ||
                FindPathRecursive(map, visited, x, y - 1, targetX, targetY) ||
                FindPathRecursive(map, visited, x, y + 1, targetX, targetY))
            {
                return true;
            }
            return false;
        }

        private int CountAliveNeighbours(bool[,] map, int x, int y)
        {
            int count = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighbourX = (x + i + map.GetLength(0)) % map.GetLength(0);
                    int neighbourY = (y + j + map.GetLength(1)) % map.GetLength(1);

                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    if (neighbourX < 0 || neighbourY < 0 || neighbourX >= map.GetLength(0) || neighbourY >= map.GetLength(1))
                    {
                        continue;
                    }

                    if (map[neighbourX, neighbourY])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private void RemoveDeadEndsWave(bool[,] map, Vector2Int start, Vector2Int end)
        {
            bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)];

            // Заполнение от начальной точки
            FloodFill(map, visited, start.x, start.y);

            // Заполнение от конечной точки
            FloodFill(map, visited, end.x, end.y);

            // Удаление тупиковых пещер
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (!visited[x, y] && map[x, y])
                    {
                        map[x, y] = false;
                    }
                }
            }

            WaveAlgorithm(map, visited, start.x, start.y); // Применение алгоритма WaveAlgorithm к всей карте
            GenerateTilemap();
        }
        private void WaveAlgorithm(bool[,] map, bool[,] visited, int startX, int startY)
        {
            Queue<Vector2Int> queue = new Queue<Vector2Int>();

            queue.Enqueue(new Vector2Int(startX, startY));

            while (queue.Count > 0)
            {
                Vector2Int current = queue.Dequeue();

                int x = current.x;
                int y = current.y;

                if (x < 0 || y < 0 || x >= map.GetLength(0) || y >= map.GetLength(1) ||!map[x, y] || visited[x, y])
                {
                    continue;
                }

                visited[x, y] = true;

                int neighbours = CountAliveNeighbours(map, x, y);

                if (neighbours == 1)
                {
                    map[x, y] = false; // удалить тупиковую пещеру
                }

                queue.Enqueue(new Vector2Int(x - 1, y));
                queue.Enqueue(new Vector2Int(x + 1, y));
                queue.Enqueue(new Vector2Int(x, y - 1));
                queue.Enqueue(new Vector2Int(x, y + 1));
            }
        }
        private void FloodFill(bool[,] map, bool[,] visited, int x, int y)
        {
            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            queue.Enqueue(new Vector2Int(x, y));

            while (queue.Count > 0)
            {
                Vector2Int current = queue.Dequeue();
                int cx = current.x;
                int cy = current.y;

                if (cx < 0 || cy < 0 || cx >= map.GetLength(0) || cy >= map.GetLength(1) || !map[cx, cy] || visited[cx, cy])
                {
                    continue;
                }

                visited[cx, cy] = true;

                queue.Enqueue(new Vector2Int(cx - 1, cy));
                queue.Enqueue(new Vector2Int(cx + 1, cy));
                queue.Enqueue(new Vector2Int(cx, cy - 1));
                queue.Enqueue(new Vector2Int(cx, cy + 1));
            }
        }
    }
}
    