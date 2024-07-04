using UnityEngine;
using Assets.Resources.Scripts.Characters;

[System.Serializable]
public class PlayerCharacter : Character {
    
    private CharactersConfig config;
    public Sprite PlayerImage {get; private set;}

    public PlayerCharacter(CharactersConfig config) : base(config.Name, config.Description, new HealStats(config.Hp), new CombatStats(config.Damage, config.Defense, config.Mana), new LeveingStats(config.Level))
    {
        this.config = config;
        PlayerImage = config.DefaultImage;
    }

    public void SetImage(Sprite newImage)
    {
        this.PlayerImage = newImage;
    }


    public override void OnAttack(int damage){}
    public override void OnDamage(int damage){}
    public override void OnHeal(int amount){}
    public override void OnDeath(){}


}