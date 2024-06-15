using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Resources.Scripts.MapGenerator;
public class Initializator : MonoBehaviour {
    public RoomGenerator generator;
    public PlayerController playerController;

    private void Awake() {
        InterfaceManager.InitializeAsync(generator);
        InterfaceManager.Initialize(playerController);
    }
}