using UnityEngine;
using Assets.Resources.Components.Configs;


namespace Assets.Resources.Inventory.Items.ItemStats
{
    public class ItemInfo {
    
        public readonly int ItemID;
        public readonly string Name;
        public readonly string Description;
        public readonly bool isLocked;
        public readonly Sprite image;
        public readonly int price;

        public ItemInfo(int itemID = -1, string name = "", string description = "", bool Locked = false, Sprite sprite = null)
        {
            ItemID = itemID;
            Name = name;
            Description = description;
            isLocked = Locked;
            image = sprite;
        }
        public ItemInfo(ItemsObjects info)
        {
            ItemID = info.Id;
            Name = info.Name;
            Description = info.Description;
            isLocked = info.IsLocked;
            image = info.Image;
        }
    }
}