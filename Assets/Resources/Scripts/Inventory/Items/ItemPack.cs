using UnityEngine;
using System.Collections.Generic;
using Assets.Resources.Scripts.Inventory.Items;
using Assets.Resources.Components.Configs;
public struct ItemPack {
    public List<Item> DefaultPack;
    public ItemPack(List<ItemsObjects> info)
    {
        DefaultPack = new List<Item> {new Item(info[0]), new Item(info[1]), new Item(info[2]), new Item(info[3]) };
    }
}