using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Resources.Scripts.MapGenerator;
using Assets.Resources.Scripts.Inventory.Items;
public class Initializator : MonoBehaviour {
    public RoomGenerator generator;
    public PlayerController playerController;
    public Village VillageGenerator;
    public Map map;
    public WorkWithInteractiveMap workInteractiveMap;
    public ListObject GenerateItem;

    private void Awake() {
        InterfaceManager.InitializeAsync(generator);
        InterfaceManager.Initialize(VillageGenerator);
        InterfaceManager.Initialize(map);
        InterfaceManager.Initialize(playerController);
        InterfaceManager.Initialize(workInteractiveMap);
        InterfaceManager.Initialize(GenerateItem);
    }
}