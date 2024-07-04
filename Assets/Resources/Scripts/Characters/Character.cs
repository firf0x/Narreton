using UnityEngine;


namespace Assets.Resources.Scripts.Characters 
{
    public abstract class Character : Stats {

        public Character(string name, string description, HealStats healStats,
         CombatStats combatStats, LeveingStats leveingStats)
         : base(name,description, healStats, combatStats, leveingStats) {}

        public abstract void OnAttack(int damage);
        public virtual void OnHighAttack(int damage)
        {
            Debug.Log("Not, realize the void");
        }
        public abstract void OnDamage(int damage);
        public abstract void OnHeal(int amount);
        public abstract void OnDeath();
    }
}