using UnityEngine;
using Assets.Resources.Scripts.Characters;
public class CharacterTester : MonoBehaviour {

    public CharactersConfig playerConfig;

    private void Awake() {
        IInfo characterInfo = new PlayerCharacter(playerConfig);
        characterInfo.GetInfo();
    }

}