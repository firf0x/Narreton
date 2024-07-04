using UnityEngine;
using Assets.Resources.Scripts.Inventory.Items;
using System.Collections.Generic;
using Assets.Resources.Components.Configs;

public class CreateItems : MonoBehaviour, IInitialize{

    public InventoryConfig inventoryInfo;
    
    public void Initialize() {
        for (int i = 0; i < inventoryInfo.AllNoneCreateItems.Count; i++)
        {
            inventoryInfo.AllReadyItems.Add(new Item(inventoryInfo.AllNoneCreateItems[i]));
        }
    }

    private void OnDestroy() {
        inventoryInfo.AllReadyItems.Clear();
    }
}