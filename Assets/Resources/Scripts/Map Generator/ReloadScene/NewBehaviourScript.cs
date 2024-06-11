using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour{
    private MainController controller;
    public PlayerInput PlayerInput;

    private float _escapePress;
    private void Awake() {
        controller = new MainController();
        controller.Enable();
    }

    private void Update() {
        _escapePress = controller.Settings.ReloadScene.ReadValue<float>();
        if(_escapePress > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
