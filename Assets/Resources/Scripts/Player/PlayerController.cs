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

    public WorkWithInteractiveMap workWithInteractive;
    public void Initialize()
    {
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
            workWithInteractive.VisiblePick(EndCell.Coordinates);        
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
            workWithInteractive.VisiblePick(EndCell.Coordinates);
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
            workWithInteractive.VisiblePick(EndCell.Coordinates);
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
            workWithInteractive.VisiblePick(EndCell.Coordinates);
        }
    }
    private void OnEnable() {
        controller = new MainController();
        controller.Enable();
        controller.Gameplay.MovementPlayer.performed += OnMovement;        
    }
    private void OnDisable() {
        controller.Gameplay.MovementPlayer.performed -= OnMovement;
        controller.Disable();
    }
}