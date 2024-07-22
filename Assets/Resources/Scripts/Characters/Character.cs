using UnityEngine;
using Assets.Resources.Scripts.Interface;

namespace Assets.Resources.Scripts.Characters 
{
    public abstract class Character {

        public Stats StatsInfo {get; set;}
        public abstract void OnAttack(IDamageSystem damage);
        public virtual void OnHighAttack(int damage)
        {
            Debug.Log("Not, realize the void");
        }
        public abstract void OnDamage(int damage);
        public abstract void OnHeal(int amount);
        public abstract void OnDeath();
        public virtual IInfo Info()
        {
            return null;
        }
    }
}