using System;
using UnityEngine;

public class CombatStats {
    
    public int damage { get; private set; }
    public int mana { get; private set; } 
    public int defense { get; private set; }

    public CombatStats(int amountDamage, int amountDefense, int amountMana)
    {
        damage = amountDamage;
        defense = amountDefense;
        mana = amountMana;
    }

}