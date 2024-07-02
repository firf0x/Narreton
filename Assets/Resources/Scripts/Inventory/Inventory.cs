using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Resources.Scripts.Inventory.Items;

public class Inventory : MonoBehaviour {
    public List<CellInventory> cellList = new List<CellInventory>();
    private ItemPack _packs;
    private List<Item> itemList = new List<Item>(); // you have in inventory items

    private void Awake() {
        _packs = new ItemPack(ListObject.listInfo);
        itemList = _packs.DefaultPack;
    }
    private void OnEnable() {
        for (int i = 0; i < itemList.Count; i++)
        {
            cellList[i].SetItem(itemList[i]);
            cellList[i].Initialize();
        }
    }
}