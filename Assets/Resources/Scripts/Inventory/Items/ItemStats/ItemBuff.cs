using UnityEngine;
using Assets.Resources.Components.Configs;


namespace Assets.Resources.Inventory.Items.ItemStats
{
    public class ItemBuff {        
        public readonly int damage;
        public readonly int healing;
        
        public ItemBuff(int damage = 0, int healing = 0)
        {
            this.damage = damage;
            this.healing = healing;
        }
        public ItemBuff(ItemsObjects info)
        {
            damage = info.Damage;
            healing = info.Healing;
        }
    }
}