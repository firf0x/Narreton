using System;
using UnityEngine;
using Assets.Resources.Scripts.Characters;
using Assets.Resources.Scripts.Interface;

[System.Serializable]
public class PlayerCharacter : Character, IDamageSystem {
    
    public event Action<Sprite> ImageChangedEvent;

    private CharactersConfig config;
    public Sprite PlayerImage {get; private set;}

    public PlayerCharacter(CharactersConfig config)
    {
        this.config = config;
        PlayerImage = config.DefaultImage;
        StatsInfo = new Stats(config.Name, config.Description, new HealStats(config.Hp), new CombatStats(config.Damage, config.Defense, config.Mana), new LeveingStats(config.Level));
        StatsInfo.healStats.DeathEvent += OnDeath;
    }

    public void SetImage(Sprite newImage) 
    {
        ImageChangedEvent?.Invoke(newImage);
        this.PlayerImage = newImage;
    }

    public override void OnAttack(IDamageSystem damage){
        damage.OnDamage(StatsInfo.combatStats.damage);
    }
    public override void OnDamage(int damage){
        StatsInfo.healStats.TakeDamage(damage);
    }
    public override void OnHeal(int amount){
        StatsInfo.healStats.Heal(amount);
    }
    public override void OnDeath(){
        Debug.Log("You dead (┬┬﹏┬┬)");
    }

    public override IInfo Info()
    {
        return StatsInfo;
    }

    ~PlayerCharacter()
    {
        StatsInfo.healStats.DeathEvent -= OnDeath;
        Debug.Log("PlayerCharacter is delete");
    }
}