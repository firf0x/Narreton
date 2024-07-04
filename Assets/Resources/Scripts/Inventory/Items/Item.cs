using UnityEngine;
using Assets.Resources.Components.Configs;

namespace Assets.Resources.Scripts.Inventory.Items
{
    [System.Serializable]
    public class Item : IItem {
        public readonly int id;
        public readonly string name;
        public readonly string description;
        public readonly bool isLocked;
        public readonly int damage;
        public readonly int healing;
        public readonly int price;
        public readonly Sprite image;

        public Item(int Id = 0, string Name = null, string Description = null,
                    bool IsLocked = true, int Damage = 0, int Healing = 0,
                    int Price = 0, Sprite Image = null)
        {
            this.id = Id;
            this.name = Name;
            this.description = Description;
            this.isLocked = IsLocked;
            this.damage = Damage;
            this.healing = Healing;
            this.price = Price;
            this.image = Image;
        }
        public Item(ItemsObjects info)
        {
            this.id = info.Id;
            this.name = info.Name;
            this.description = info.Description;
            this.isLocked = info.IsLocked;
            this.damage = info.Damage;
            this.healing = info.Healing;
            this.price = info.Price;
            this.image = info.Image;
        }
        public void GetInfo()
        {
            Debug.Log("Info Item \n"
                + $"Id: {id}\n"
                + $"Name: {name}\n"
                + $"Description: {description}\n"
                + $"IsLocked: {isLocked}\n"
                + $"Damage: {damage}\n"
                + $"Healing: {healing}\n"
                + $"Price: {price}"
            );
        }    
    }
}