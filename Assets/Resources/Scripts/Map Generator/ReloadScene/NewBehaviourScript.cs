using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Assets.Resources.Scripts.MapGenerator;
public class NewBehaviourScript : MonoBehaviour{
    private MainController controller;
    public PlayerInput PlayerInput;
    public GameObject Cameraobj;
    public GameObject Uiobj;
    private float _KeyPress_R;
    private float _KeyPress_Escape;

    private void Awake() {
        controller = new MainController();
        controller.Enable();
        
        controller.Gameplay.ReloadScene.performed += OnReloadScene;
        controller.Gameplay.MenuActive.performed += OnMenuActive;

        Cameraobj.transform.position = new Vector3(InteractiveGenerator.EntryCell.Coordinates.x, InteractiveGenerator.EntryCell.Coordinates.y, -10);
    }


    public void OnReloadScene(InputAction.CallbackContext context)
    {
        _KeyPress_R = context.ReadValue<float>();
        if (_KeyPress_R > 0)
            SceneManager.LoadScene(0);

    }
    public void OnMenuActive(InputAction.CallbackContext context)
    {
        _KeyPress_Escape = context.ReadValue<float>();
        if(_KeyPress_Escape > 0)
        {
            Time.timeScale = 0; 
            Uiobj.SetActive(true);
        }
    }
    public void Continued()
    {
        Time.timeScale = 1; 
        Uiobj.SetActive(false);
    }
    public void Exit() => Application.Quit();
}
