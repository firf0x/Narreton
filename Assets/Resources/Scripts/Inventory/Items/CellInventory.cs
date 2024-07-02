using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Inventory.Items
{
    public class CellInventory : MonoBehaviour, IInitialize {
        public Item item {get; private set;}
        private Vector2 position;

        public void Initialize() {
            position = new Vector2(transform.position.x, transform.position.y);
            gameObject.GetComponent<Image>().sprite = item.image;
        }

        public void SetItem(Item item) => this.item = item; 
    }
}