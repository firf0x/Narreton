using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Assets.Resources.Scripts.MapGenerator;
public class NewBehaviourScript : MonoBehaviour{
    public GameObject Cameraobj;
    public PlayerController playerController;
    public GameObject Uiobj;
    private float _KeyPress_R;
    private float _KeyPress_Escape;
    private float _KeyPress_Enter;
    public UnityInputSystem inputSystem;
    public WorkWithInteractiveMap WorkInteractiveMap;
    
    private void Awake() 
    {
        inputSystem.ReloadSceneEvent += OnReloadScene;
        inputSystem.MenuActiveEvent += OnMenuActive;
        inputSystem.EntryEvent += OnEnter;

        Cameraobj.transform.position = new Vector3(InteractiveGenerator.EntryCell.Coordinates.x, InteractiveGenerator.EntryCell.Coordinates.y, -10);
    }


    public void OnReloadScene(float context)
    {
        _KeyPress_R = context;
        if (_KeyPress_R > 0)
            SceneManager.LoadScene(1);

    }
    public void OnMenuActive(float context)
    {
        _KeyPress_Escape = context;
        if(_KeyPress_Escape > 0)
        {
            Time.timeScale = 0;
            IActive active = playerController;
            active.DisActive();
            Uiobj.SetActive(true);
        }
    }

    public void OnEnter(float context)
    {
        _KeyPress_Enter = context;
        if(_KeyPress_Enter > 0)
        {
            Debug.Log("Enter");

            WorkInteractiveMap.SwitchTileMap();
        }
    }
    public void Continued()
    {
        Time.timeScale = 1;
        IActive active = playerController;
        active.Active(); 
        Uiobj.SetActive(false);
    }
    public void Exit()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(0);
    }
    private void OnDisable() {
        inputSystem.ReloadSceneEvent -= OnReloadScene;
        inputSystem.MenuActiveEvent -= OnMenuActive;
    }
    private void OnDestroy() {
        inputSystem.ReloadSceneEvent -= OnReloadScene;
        inputSystem.MenuActiveEvent -= OnMenuActive;
    }
}
