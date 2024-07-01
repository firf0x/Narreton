using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Config/Items/ItemsObjects")]
public class ItemsObjects : ScriptableObject {
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private bool isLocked;
    [SerializeField] private int damage;
    [SerializeField] private int healing;
    [SerializeField] private int price;
    [SerializeField] private Sprite image;

    public int Id => this.id;
    public string Name => this.name;
    public string Description => this.description;
    public bool IsLocked => this.isLocked;
    public int Damage => this.damage;
    public int Healing => this.healing;
    public int Price => this.price;
    public Sprite Image => this.image; 
}