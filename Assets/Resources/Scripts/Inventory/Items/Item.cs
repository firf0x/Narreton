using UnityEngine;
using Assets.Resources.Components.Configs;
using Assets.Resources.Inventory.Items.ItemStats;

namespace Assets.Resources.Scripts.Inventory.Items
{
    [System.Serializable]
    public class Item : IItem {
        public ItemStats Stats { get; private set; }

        public Item(ItemsObjects info)
        {
            Stats = new ItemStats(info);
        }
        public void GetInfo()
        {
            Debug.Log("Info Item \n"
                + $"Id: {Stats.Info.ItemID}\n"
                + $"Name: {Stats.Info.Name}\n"
                + $"Description: {Stats.Info.Description}\n"
                + $"IsLocked: {Stats.Info.isLocked}\n"
                + $"Damage: {Stats.BuffInfo.damage}\n"
                + $"Healing: {Stats.BuffInfo.healing}\n"
                + $"Price: {Stats.Info.price}"
            );
        }    
    }
}