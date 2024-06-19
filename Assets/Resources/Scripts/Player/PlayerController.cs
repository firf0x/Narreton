using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Assets.Resources.Scripts.MapGenerator;
public class PlayerController : MonoBehaviour, IInitialize, IActive {
    public TileBase PlayerTileBase;
    private Vector2 moveble;
    public UnityInputSystem inputSystem;
    private Vector2Int _currentPosition;
    private Vector2Int _currentPositionInVillage;
    public static Vector2Int CurrentPosition;
    public static Vector2Int CurrentPositionInVillage;
    public WorkWithInteractiveMap workWithInteractive;
    public void Initialize()
    {
        inputSystem.MovementPlayerEvent += OnMovement;

        _currentPosition = InteractiveGenerator.EntryCell.Coordinates;
        _currentPositionInVillage = Village.EntryCell.Coordinates;

        CurrentPosition = _currentPosition;
        CurrentPositionInVillage = _currentPositionInVillage;
        
        ISetTile cell = Village.EntryCell;
        Debug.Log(Village.EntryCell.Tile.name);

        cell.SetTile(TileMap.tileMapVillage, PlayerTileBase);

        cell = InteractiveGenerator.EntryCell;
        cell.SetTile(TileMap.tileMap, PlayerTileBase);
    }

    private void OnDisable() {
        inputSystem.MovementPlayerEvent -= OnMovement;
    }
    public void OnMovement(Vector2 context)
    {
        // Set Value Vector2
        moveble = context;

        // Village
        // X
        if(moveble.x == 1 && Map.IsVillage == true)
        {
            Debug.Log("Tap Village");
            _currentPositionInVillage.x += 1;
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPositionInVillage.x - 1, _currentPositionInVillage.y), CellList.villageCellList, out Cell StartCell);
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPositionInVillage.x, _currentPositionInVillage.y), CellList.villageCellList, out Cell EndCell);
            
            if(EndCell.IsAlive == false)
            {
                _currentPositionInVillage.x -= 1;
                return;
            }

            ISetTile cell = StartCell;
            cell.SetTile(TileMap.tileMapVillage); // set default tile
            cell = EndCell;
            cell.SetTile(TileMap.tileMapVillage, PlayerTileBase); // set dinamic tile
            workWithInteractive.TalkPick(EndCell.Coordinates);
            workWithInteractive.VisiblePickVillage(EndCell.Coordinates);
            CurrentPositionInVillage = _currentPositionInVillage;
        }
        else if(moveble.x == -1 && Map.IsVillage == true)
        {
            Debug.Log("Tap Village");
            _currentPositionInVillage.x -= 1;
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPositionInVillage.x + 1, _currentPositionInVillage.y), CellList.villageCellList, out Cell StartCell);
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPositionInVillage.x, _currentPositionInVillage.y), CellList.villageCellList, out Cell EndCell);
            
            if(EndCell.IsAlive == false)
            {
                //Debug.Log("Шаг");
                _currentPositionInVillage.x += 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(TileMap.tileMapVillage); // set default tile
            cell = EndCell;
            cell.SetTile(TileMap.tileMapVillage, PlayerTileBase); // set dinamic tile
            workWithInteractive.TalkPick(EndCell.Coordinates);
            workWithInteractive.VisiblePickVillage(EndCell.Coordinates);
            CurrentPositionInVillage = _currentPositionInVillage;
        }
        // Y
        if(moveble.y == 1 && Map.IsVillage == true)
        {
            Debug.Log("Tap Village");
            _currentPositionInVillage.y += 1;
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPositionInVillage.x, _currentPositionInVillage.y - 1), CellList.villageCellList, out Cell StartCell);
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPositionInVillage.x, _currentPositionInVillage.y), CellList.villageCellList, out Cell EndCell);

            if(EndCell.IsAlive == false)
            {
                _currentPositionInVillage.y -= 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(TileMap.tileMapVillage); // set default tile
            cell = EndCell;
            cell.SetTile(TileMap.tileMapVillage, PlayerTileBase); // set dinamic tile
            workWithInteractive.TalkPick(EndCell.Coordinates);
            workWithInteractive.VisiblePickVillage(EndCell.Coordinates);
            CurrentPositionInVillage = _currentPositionInVillage;
        }
        else if(moveble.y == -1 && Map.IsVillage == true)
        {
            Debug.Log("Tap Village");
            _currentPositionInVillage.y -= 1;
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPositionInVillage.x, _currentPositionInVillage.y + 1), CellList.villageCellList, out Cell StartCell);
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPositionInVillage.x, _currentPositionInVillage.y), CellList.villageCellList, out Cell EndCell);
            
            if(EndCell.IsAlive == false)
            {
                _currentPositionInVillage.y += 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(TileMap.tileMapVillage); // set default tile
            cell = EndCell;
            cell.SetTile(TileMap.tileMapVillage, PlayerTileBase); // set dinamic tile
            workWithInteractive.TalkPick(EndCell.Coordinates);
            workWithInteractive.VisiblePickVillage(EndCell.Coordinates);
            CurrentPositionInVillage = _currentPositionInVillage;
        }
    
        // Cave
        // X
        if(moveble.x == 1 && Map.IsVillage == false)
        {
            Debug.Log("Tap Cave");
            _currentPosition.x += 1;
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPosition.x - 1, _currentPosition.y), CellList.cellList, out Cell StartCell);
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPosition.x, _currentPosition.y), CellList.cellList, out Cell EndCell);
            
            if(EndCell.Tile == RoomGenerator.borderTile)
            {
                _currentPosition.x -= 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(TileMap.tileMap); // set default tile
            cell = EndCell;
            cell.SetTile(TileMap.tileMap, PlayerTileBase); // set dinamic tile
            workWithInteractive.VisiblePick(EndCell.Coordinates);
            CurrentPosition = _currentPosition;
        }
        else if(moveble.x == -1 && Map.IsVillage == false)
        {
            Debug.Log("Tap Cave");
            _currentPosition.x -= 1;
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPosition.x + 1, _currentPosition.y), CellList.cellList, out Cell StartCell);
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPosition.x, _currentPosition.y), CellList.cellList, out Cell EndCell);
            
            if(EndCell.Tile == RoomGenerator.borderTile)
            {
                _currentPosition.x += 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(TileMap.tileMap); // set default tile
            cell = EndCell;
            cell.SetTile(TileMap.tileMap, PlayerTileBase); // set dinamic tile
            workWithInteractive.VisiblePick(EndCell.Coordinates);
            CurrentPosition = _currentPosition;
        }
        // Y
        if(moveble.y == 1 && Map.IsVillage == false)
        {
            Debug.Log("Tap Cave");
            _currentPosition.y += 1;
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPosition.x, _currentPosition.y - 1), CellList.cellList, out Cell StartCell);
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPosition.x, _currentPosition.y), CellList.cellList, out Cell EndCell);
            
            if(EndCell.Tile == RoomGenerator.borderTile)
            {
                _currentPosition.y -= 1;
                return;
            }
            
            Debug.Log("Tap Cave");
            ISetTile cell = StartCell;
            cell.SetTile(TileMap.tileMap); // set default tile
            cell = EndCell;
            cell.SetTile(TileMap.tileMap, PlayerTileBase); // set dinamic tile
            workWithInteractive.VisiblePick(EndCell.Coordinates);
            CurrentPosition = _currentPosition;
        }
        else if(moveble.y == -1 && Map.IsVillage == false)
        {
            Debug.Log("Tap Cave");
            _currentPosition.y -= 1;
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPosition.x, _currentPosition.y + 1), CellList.cellList, out Cell StartCell);
            CellList.GetCellOfCoordinate(new Vector2Int(_currentPosition.x, _currentPosition.y), CellList.cellList, out Cell EndCell);
            
            if(EndCell.Tile == RoomGenerator.borderTile)
            {
                _currentPosition.y += 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(TileMap.tileMap); // set default tile
            cell = EndCell;
            cell.SetTile(TileMap.tileMap, PlayerTileBase); // set dinamic tile
            workWithInteractive.VisiblePick(EndCell.Coordinates);
            CurrentPosition = _currentPosition;
        }
    }

    public void Active()
    {
        inputSystem.MovementPlayerEvent += OnMovement;
    }
    public void DisActive()
    {
        inputSystem.MovementPlayerEvent -= OnMovement;
    }
}