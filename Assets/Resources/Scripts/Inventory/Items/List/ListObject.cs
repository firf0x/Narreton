using UnityEngine;
using Assets.Resources.Scripts.Inventory.Items;
using System.Collections.Generic;

public class ListObject : MonoBehaviour, IInitialize{

    public List<ItemsObjects> _listInfo = new List<ItemsObjects>();
    public static List<ItemsObjects> listInfo = new List<ItemsObjects>(); // Configs
    public static List<Item> listItems = new List<Item>(); // Items
    
    public void Initialize() {
        for (int i = 0; i < _listInfo.Count; i++)
        {
            listItems.Add(new Item(_listInfo[i]));
        }
        listInfo = _listInfo;
    }
    private void OnDestroy() {
        listItems.Clear();
        _listInfo.Clear();
        listInfo.Clear();
    }
}