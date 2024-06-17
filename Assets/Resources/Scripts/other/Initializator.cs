using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Resources.Scripts.MapGenerator;
public class Initializator : MonoBehaviour {
    public RoomGenerator generator;
    public PlayerController playerController;
    public Village VillageGenerator;
    public Map map;
    public WorkWithInteractiveMap workInteractiveMap;

    private void Awake() {
        InterfaceManager.InitializeAsync(generator);
        InterfaceManager.Initialize(VillageGenerator);
        InterfaceManager.Initialize(map);
        InterfaceManager.Initialize(playerController);
        InterfaceManager.Initialize(workInteractiveMap);
    }
}