using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Inventory.Items
{
    public class CellInventory : MonoBehaviour, IInitialize {
        private Sprite image;
        private Vector2 position;

        public void Initialize() {
            position = new Vector2(transform.position.x, transform.position.y);
            gameObject.GetComponent<Image>().sprite = image;
        }

        public void SetItem(Sprite sprite) => this.image = sprite; 
    }
}