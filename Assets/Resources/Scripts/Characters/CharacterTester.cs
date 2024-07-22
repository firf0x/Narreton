using UnityEngine;
using Assets.Resources.Scripts.Characters;
using Assets.Resources.Scripts.FightSystem;
public class CharacterTester : MonoBehaviour {

    public CharactersConfig playerConfig;
    public CharactersConfig EnemyConfig;
    public MainFight fight;

    private void Awake() {
        var _object = new PlayerCharacter(playerConfig);
        IInfo characterInfo = _object.Info();
        characterInfo.GetInfo();

        var enemy = new Glor(EnemyConfig);
        IInfo enemyInfo = enemy.Info();
        enemyInfo.GetInfo();

        fight.GetCharacter(_object, enemy);

    }

}