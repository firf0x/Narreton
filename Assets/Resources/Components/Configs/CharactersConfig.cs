using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Config/Character/CharactersConfig")]
public class CharactersConfig : ScriptableObject {
    
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _hp;
    [SerializeField] private int _damage;
    [SerializeField] private int _defense;
    [SerializeField] private int _mana;
    [SerializeField] private int _level;
    [SerializeField] private Sprite _defaultImage;
    
    public string Name => this._name;
    public string Description => this._description;
    public int Hp => this._hp;
    public int Damage => this._damage;
    public int Defense => this._defense;
    public int Mana => this._mana;
    public int Level => this._level;
    public Sprite DefaultImage => this._defaultImage;
}