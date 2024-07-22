using UnityEngine;
using Assets.Resources.Components.Configs;

namespace Assets.Resources.Inventory.Items.ItemStats {
    public class ItemStats {
        
        public readonly ItemInfo Info;
        public readonly ItemBuff BuffInfo;

        public ItemStats(ItemsObjects info) 
        {
            Info = new ItemInfo(info);
            BuffInfo = new ItemBuff(info);
        }
        public ItemStats(ItemInfo info, ItemBuff itemBuff)
        {
            Info = info;
            BuffInfo = itemBuff;
        }
    }
}