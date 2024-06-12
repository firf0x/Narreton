using UnityEngine;
using Assets.Resources.Scripts.MapGenerator;
public class Initializator : MonoBehaviour {
    public RoomGenerator generator;
    public PlayerController playerController;

    private void Awake() {
        IInitialize _object = generator;
        _object.Initialize();
        //_object = playerController;
        //_object.Initialize();
    }
}