using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
namespace Assets.Resources.Scripts.MapGenerator
{
    public class RoomGenerator : MonoBehaviour, IInitialize
    {
        public Tilemap tileMap;
        public List<TileBase> EnemyTileBaseList = new List<TileBase>();
        public List<TileBase> PlatformTileBaseList = new List<TileBase>();
        public List<TileBase> DefaultTileBaseList = new List<TileBase>();
        public List<TileBase> InExitTileBaseList = new List<TileBase>();
        public List<TileBase> HouseTilebaseList = new List<TileBase>();

        [Range(0, 100)]
        public int HouseSizeGenerate;




        public TileBase Tile_1; // alive tile
        public TileBase BorderTile; 
        public static TileBase borderTile; 
        public TileBase Tile_2; // dead tile
        public Vector2Int Size;
        [Range(0, 1)]
        public float chanceToStartAlive;
        public int deathLimit;
        public int birthLimit;
        public int numberOfSteps;
        private bool[,] _map; // ReadyMap
        private List<Vector2Int> aliveCells = new List<Vector2Int>(); // Alive Cells Map 
        public int RemoveEnds;
        public Vector2Int startPoint; // стартовая точка
        public Vector2Int endPoint; // конечная точка

        public async void Initialize()
        {
            borderTile = BorderTile;
            await InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            try
            {
                Debug.Log("Инициализация генерации начата");
                await GenerateMapAsync();
                await FindPathAsync();
                await GenerateInteractiveCellsAsync();
                Debug.Log("Инициализация генерации завершена");
            }
            catch (Exception ex)
            {
                Debug.LogError("Ошибка инициализации: " + ex.Message);
            }
        }
        private async Task GenerateMapAsync()
        {
            // генерация карты
            Debug.Log("Начало генерации карты");
            _map = new bool[Size.x, Size.y];
            CellList.GenerateCells(_map);
            TileMap.SetTileMap(tileMap);
            InitialiseMap(ref _map);
            GenerateTilemap();
        }

        private async Task<bool> FindPathAsync()
        {
            // поиск пути
            Debug.Log("Проверка пути");
            bool pathFound = FindPath(_map, startPoint, endPoint);
            while (!pathFound)
            {
                InitialiseMap(ref _map);
                GenerateTilemap();
                pathFound = FindPath(_map, startPoint, endPoint);
            }
            Debug.Log("Проверка пути Окончена");
            return pathFound;
        }
            
        private async Task GenerateInteractiveCellsAsync()
        {
            Debug.Log("Начало генерации инерактивных клеток");
            // генерация интерактивных клеток
            RemoveDeadEndsWave(ref _map, startPoint, endPoint);
            GenerateCells(_map);
            GenerateBorder(ref _map);
            InteractiveGenerator.SetMap(CellList.cellList);
            InteractiveGenerator.GenAliveCells();
            InteractiveGenerator.GenEntryAndExit(InExitTileBaseList);
            InteractiveGenerator.SetSizeHouse(HouseSizeGenerate);
            InteractiveGenerator.GenHouseOnMap(HouseTilebaseList);
            Debug.Log("Окончание генерации инерактивных клеток");
        }

        private void InitialiseMap(ref bool[,] map)
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
                _map = Step(ref _map);
            }

            for (int x = 0; x < _map.GetLength(0); x++)
            {
                for (int y = 0; y < _map.GetLength(1); y++)
                {
                    if (_map[x, y])
                    {
                        TileMap.tileMap.SetTile(new Vector3Int(x, y, 0), DefaultTileBaseList[0]); // set alive tile
                    }
                    else
                    {
                        TileMap.tileMap.SetTile(new Vector3Int(x, y, 0), DefaultTileBaseList[1]); // set dead tile
                    }
                }
            }
        }

        private void GenerateBorder(ref bool[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (!map[x, y])
                    {
                        // Проверяем соседей клетки
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
                                    // Если соседняя клетка жива, то это граница
                                    CellList.GetCellOfCoordinate(x, y, out Cell CellBorder);
                                    CellBorder.Tile = BorderTile;
                                    TileMap.tileMap.SetTile(new Vector3Int(x, y, 0), BorderTile); // Set border tile
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void GenerateCells(bool[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    CellList.cellList[x, y] = new Cell(new Vector2Int(x, y), map[x, y], DefaultTileBaseList);
                }
            }
        }

        private bool[,] Step(ref bool[,] oldMap)
        {
            bool[,] newMap = new bool[oldMap.GetLength(0), oldMap.GetLength(1)];

            for (int x = 0; x < oldMap.GetLength(0); x++)
            {
                for (int y = 0; y < oldMap.GetLength(1); y++)
                {
                    int neighbours = CountAliveNeighbours(ref oldMap, x, y);
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

        private int CountAliveNeighbours(ref bool[,] map, int x, int y)
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
        private void RemoveDeadEndsWave(ref bool[,] map, Vector2Int start, Vector2Int end)
        {
            bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)];

            // Заполнение от начальной точки
            FloodFill(ref map, visited, start.x, start.y);

            // Заполнение от конечной точки
            FloodFill(ref map, visited, end.x, end.y);

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

            WaveAlgorithm(ref map, visited, start.x, start.y); // Применение алгоритма WaveAlgorithm к всей карте
            GenerateTilemap();
        }
        private void WaveAlgorithm(ref bool[,] map, bool[,] visited, int startX, int startY)
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

                int neighbours = CountAliveNeighbours(ref map, x, y);

                if (neighbours == 1)
                {
                    map[x, y] = false; // удалить тупиковую пещеру
                }
                else
                {
                    aliveCells.Add(new Vector2Int(x, y)); // добавить живую клетку в список
                }

                queue.Enqueue(new Vector2Int(x - 1, y));
                queue.Enqueue(new Vector2Int(x + 1, y));
                queue.Enqueue(new Vector2Int(x, y - 1));
                queue.Enqueue(new Vector2Int(x, y + 1));
            }
        }
        private void FloodFill(ref bool[,] map, bool[,] visited, int x, int y)
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

        private void OnDestroy() {
            aliveCells.Clear();
            Array.Clear(_map, 0, _map.Length);
            CellList.Clear();
            InteractiveGenerator.ClearMap();
        }
    }
}
    