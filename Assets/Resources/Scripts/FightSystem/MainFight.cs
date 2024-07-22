using UnityEngine;
using Assets.Resources.Scripts.Characters;
using Assets.Resources.Scripts.Interface;

namespace Assets.Resources.Scripts.FightSystem
{
    public class MainFight : MonoBehaviour {
        public Character PlayerCharacter;
        public Character EnemyCharacter;

        public Character GetCharacter(Character character1, Character character2)
        {
            PlayerCharacter = character1;
            EnemyCharacter = character2;
            return null;
        }

        public void Attack()
        {
            IDamageSystem playerDamage = (IDamageSystem)PlayerCharacter;
            IDamageSystem enemyDamage = (IDamageSystem)EnemyCharacter;

            playerDamage.OnAttack(enemyDamage);
            enemyDamage.OnAttack(playerDamage);
        }

        public void Heal()
        {

        }
        public void Logs()
        {
            IInfo characterInfo = PlayerCharacter.Info();
            characterInfo.GetInfo();
            IInfo EnemyCharacterInfo = EnemyCharacter.Info();
            EnemyCharacterInfo.GetInfo();
        }
    }
}