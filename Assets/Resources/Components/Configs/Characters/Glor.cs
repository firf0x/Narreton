using System;
using UnityEngine;
using Assets.Resources.Scripts.Characters;
using Assets.Resources.Scripts.Interface;

public class Glor : Character, IDamageSystem {
    public event Action<Sprite> ImageChangedEvent;
    private CharactersConfig config;
    public Sprite CharacterImage { get; private set; }
    public Glor(CharactersConfig config)
    {
        this.config = config;
        CharacterImage = config.DefaultImage;
        StatsInfo = new Stats(config.Name, config.Description, new HealStats(config.Hp), new CombatStats(config.Damage, config.Defense, config.Mana), new LeveingStats(config.Level));
        StatsInfo.healStats.DeathEvent += OnDeath;
    }

    public void SetImage(Sprite newImage) 
    {
        ImageChangedEvent?.Invoke(newImage);
        this.CharacterImage = newImage;
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
        Debug.Log("Ты умер");
    }

    public override IInfo Info()
    {
        return StatsInfo;
    }

    ~Glor()
    {
        StatsInfo.healStats.DeathEvent -= OnDeath;
        Debug.Log($"{StatsInfo.name} is delete");
    }
}