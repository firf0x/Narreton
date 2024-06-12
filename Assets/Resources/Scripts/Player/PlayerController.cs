using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour, IInitialize {
    
    public TileBase PlayerTileBase;
    private Tilemap _tileMap;
    private Vector3Int _currentPosition;

    public void Initialize()
    {
        
    }
}