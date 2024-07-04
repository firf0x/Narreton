using System;
using UnityEngine;

public class LeveingStats : ILevel {
    
    //--------------------------------------------------------
    // Events
    public event Action LevelUpEvent;
    
    //--------------------------------------------------------
    //Parametrs
    
    // Level 
    public int level { get; private set; }

    // Max level
    public int maxLevel { get; private set; }
    
    // Exp
    public int exp { get; private set; }

    //--------------------------------------------------------
    // Constructor
    public LeveingStats(int level = 0)
    {
        this.level = level;
        this.maxLevel = 100;
        exp = 0;
    }

    //--------------------------------------------------------
    // Level realize.

    // Character get up xp.
    public void GainXp(int amount)
    {
        exp += amount;

        if(exp >= GetXpForNextLevel()) LevelUp();
    }

    private int GetXpForNextLevel()
    {
        return level * 100;
    }

    private void LevelUp() 
    {
        level++;
        LevelUpEvent?.Invoke();
    }
    //--------------------------------------------------------
}