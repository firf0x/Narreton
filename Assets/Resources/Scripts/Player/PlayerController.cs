using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using Assets.Resources.Scripts.MapGenerator;
public class PlayerController : MonoBehaviour, IInitialize {
    public TileBase PlayerTileBase;
    private MainController controller;
    public PlayerInput PlayerInput;
    private Vector2 moveble;
    private Vector2Int _currentPosition;
    public void Initialize()
    {
        controller = new MainController();
        controller.Enable();
        controller.MovePlayer.Movement.performed += OnMovement;
        _currentPosition = InteractiveGenerator.EntryCell.Coordinates;
        
        ISetTile cell = InteractiveGenerator.EntryCell;
        cell.SetTile(PlayerTileBase);
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        // Set Value Vector2
        moveble = context.ReadValue<Vector2>();


        // X
        if(moveble.x == 1)
        {
            _currentPosition.x += 1;
            CellList.GetCellOfCoordinate(_currentPosition.x - 1, _currentPosition.y, out Cell StartCell);
            CellList.GetCellOfCoordinate(_currentPosition.x, _currentPosition.y, out Cell EndCell);
            
            if(EndCell.Tile == RoomGenerator.borderTile)
            {
                _currentPosition.x -= 1;
                return;
            }

            ISetTile cell = StartCell;
            cell.SetTile(); // set default tile
            cell = EndCell;
            cell.SetTile(PlayerTileBase); // set dinamic tile
        }
        else if(moveble.x == -1)
        {
            _currentPosition.x -= 1;
            CellList.GetCellOfCoordinate(_currentPosition.x + 1, _currentPosition.y, out Cell StartCell);
            CellList.GetCellOfCoordinate(_currentPosition.x, _currentPosition.y, out Cell EndCell);
            
            if(EndCell.Tile == RoomGenerator.borderTile)
            {
                _currentPosition.x += 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(); // set default tile
            cell = EndCell;
            cell.SetTile(PlayerTileBase); // set dinamic tile
        }
        // Y
        if(moveble.y == 1)
        {
            _currentPosition.y += 1;
            CellList.GetCellOfCoordinate(_currentPosition.x, _currentPosition.y - 1, out Cell StartCell);
            CellList.GetCellOfCoordinate(_currentPosition.x, _currentPosition.y, out Cell EndCell);
            
            if(EndCell.Tile == RoomGenerator.borderTile)
            {
                _currentPosition.y -= 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(); // set default tile
            cell = EndCell;
            cell.SetTile(PlayerTileBase); // set dinamic tile

        }
        else if(moveble.y == -1)
        {
            _currentPosition.y -= 1;
            CellList.GetCellOfCoordinate(_currentPosition.x, _currentPosition.y + 1, out Cell StartCell);
            CellList.GetCellOfCoordinate(_currentPosition.x, _currentPosition.y, out Cell EndCell);
            
            if(EndCell.Tile == RoomGenerator.borderTile)
            {
                _currentPosition.y += 1;
                return;
            }
            
            ISetTile cell = StartCell;
            cell.SetTile(); // set default tile
            cell = EndCell;
            cell.SetTile(PlayerTileBase); // set dinamic tile
        }
    }
}


/*
*/