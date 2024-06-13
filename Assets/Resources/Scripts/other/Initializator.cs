using UnityEngine;
using Assets.Resources.Scripts.MapGenerator;
public class Initializator : MonoBehaviour {
    public RoomGenerator generator;
    public PlayerController playerController;

    private void Awake() {
        InterfaceManager.Initialize(generator);
        InterfaceManager.Initialize(playerController);
    }
}