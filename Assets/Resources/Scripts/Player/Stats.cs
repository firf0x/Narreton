using UnityEngine;

public class Stats {
    public string name {get; private set;}
    public int xp {get; private set;}
    public int level {get; private set;}
    
    public int hp {get; private set;}
    public int damage {get; private set;}
    public int mana {get; private set;}
    public int defense {get; private set;}

    public Stats(string name = "", int xp = 0, int level = 0,
                 int hp = 0, int damage = 0, int mana = 0, int defense = 0)
    {
        this.name = name;
        this.xp = xp;
        this.level = level;
        this.hp = hp;
        this.damage = damage;
        this.mana = mana;
        this.defense = defense;
    }

    public void Update()
    {
        if((level % 5) == 1)
        {
            hp += 5;
            damage += 4;
            mana += 10;
            defense += 5;
        }
    }
}