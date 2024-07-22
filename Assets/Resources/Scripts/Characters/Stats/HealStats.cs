using System;
using UnityEngine;

public class HealStats : IHeal {
    
    //--------------------------------------------------------
    //Events
    public event Action DeathEvent;
    
    //--------------------------------------------------------
    //Parametrs

    // Hp
    public int hp { get; private set; }
    // Max Hp
    public int maxHp { get; private set; }

    //--------------------------------------------------------
    /// <summary>
    /// Constructor.
    /// </summary>
    public HealStats(int maxHp)
    {
        this.maxHp = maxHp;
        hp = maxHp;
    }
    
    //--------------------------------------------------------
    // Heal realize

    // Take damage from an enemy
    public void TakeDamage(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            if(hp <= 0)
            {
                Death();
            }
        }
    }

    // Item treatment
    public void Heal(int amount)
    {
        hp += amount;
        
        if(hp > maxHp) hp = maxHp;
    }

    //here

    // Character dead
    private void Death() => DeathEvent?.Invoke();

    //--------------------------------------------------------
}