using UnityEngine;

public class Stats : IInfo {
    public string name { get; private set; }
    public string description { get; private set; }
    
    public HealStats healStats { get; private set; }
    public CombatStats combatStats { get; private set; }
    public LeveingStats leveingStats { get; private set; }

    // Constructor
    public Stats(string name, string description, HealStats healStats, CombatStats combatStats, LeveingStats leveingStats)
    {
        this.name = name;
        this.description = description;

        this.healStats = healStats;
        this.combatStats = combatStats;
        this.leveingStats = leveingStats;
    }
    
    // Set new name or rename.
    public void SetName(string newName) => this.name = newName;

    // Set new description or rename desctiption.
    public void SetDescription(string newDescription) => this.description = newDescription;

    // Get info about this stats.
    public void GetInfo() => Debug.Log($"Debug Info \n Name {name} \n XP {leveingStats.exp} \n lvl {leveingStats.level} \n HP {healStats.hp} \n Damage {combatStats.damage}");
}