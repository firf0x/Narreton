using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class UnityInputSystem : MonoBehaviour {
    
    [Header("PlayerInput")]
    public static MainController mainController;
    public PlayerInput playerInput;

    [Header("InputActionReference")]
    public InputActionReference MovementCameraReference;
    public InputActionReference MovementPlayerReference;
    public InputActionReference ReloadSceneReference;
    public InputActionReference MenuActiveReference;
    public InputActionReference EntryBattonReference;

    public event Action<Vector2> MovementCameraEvent;
    public event Action<Vector2> MovementPlayerEvent; 
    public event Action<float> ReloadSceneEvent; 
    public event Action<float> MenuActiveEvent; 
    public event Action<float> EntryEvent; 

    

    private void OnEnable() {
        mainController = new MainController();
        mainController.Enable();

        // Set Active Events
        MovementCameraReference.action.performed += InvokeEventMovementCamera;
        MovementPlayerReference.action.performed += InvokeEventMovementPlayer;
        ReloadSceneReference.action.performed += InvokeEventReloadScene;
        MenuActiveReference.action.performed += InvokeEventMenuActive;
        EntryBattonReference.action.performed += InvokeEventEntry;
    }
    private void OnDestroy() {
        // Set Disactive Events
        MovementCameraReference.action.performed -= InvokeEventMovementCamera;
        MovementPlayerReference.action.performed -= InvokeEventMovementPlayer;
        ReloadSceneReference.action.performed -= InvokeEventReloadScene;
        MenuActiveReference.action.performed -= InvokeEventMenuActive;
        EntryBattonReference.action.performed -= InvokeEventEntry;

        mainController.Disable();
        mainController.Dispose();
    }

    public void SwitchActionMap()
    {
        switch(playerInput.currentActionMap.name)
        {
            case "Gameplay":
                playerInput.SwitchCurrentActionMap("Mouse");        
            break;

            case "Mouse":
                playerInput.SwitchCurrentActionMap("Gameplay");
            break;

            default:
                Debug.Log($"Непонятный ActionMap → {playerInput.currentActionMap.name}");
            break;
        }
    }

    public void InvokeEventMovementCamera(InputAction.CallbackContext context) => MovementCameraEvent?.Invoke(context.ReadValue<Vector2>());
    public void InvokeEventMovementPlayer(InputAction.CallbackContext context) => MovementPlayerEvent?.Invoke(context.ReadValue<Vector2>());
    public void InvokeEventReloadScene(InputAction.CallbackContext context) => ReloadSceneEvent?.Invoke(context.ReadValue<float>());
    public void InvokeEventMenuActive(InputAction.CallbackContext context) => MenuActiveEvent?.Invoke(context.ReadValue<float>());
    public void InvokeEventEntry(InputAction.CallbackContext context) => EntryEvent?.Invoke(context.ReadValue<float>());
}