using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Inventory.Items;


namespace Assets.Resources.Components.Configs
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "Config/Inventory/InventoryConfig")]
    public class InventoryConfig : ScriptableObject {

        [SerializeField] private List<ItemsObjects> allNoneCreateItems; // None create Items.
        
        //TODO: If necessary 
        // [SerializeField] private List<Item> allReadyItems; // Ready create Items.

        public List<ItemsObjects> AllNoneCreateItems => this.allNoneCreateItems;
        //[Header ("Все созданные предметы (не трогать)")] 
        public List<Item> AllReadyItems {get; set;} = new List<Item>(); // don't touch
    }
}
