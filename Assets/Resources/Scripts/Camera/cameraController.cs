using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Assets.Resources.Scripts.Camera
{
    public class cameraController : MonoBehaviour{
        private MainController controller;
        public PlayerInput PlayerInput;
        private Vector2 cameraInput;
        private Rigidbody2D _rb;

        [SerializeField] private float Speed;

        private void Awake() {
            controller = new MainController();
            controller.Enable();

            _rb = gameObject.GetComponent<Rigidbody2D>();
            if(PlayerInput == null)
                Debug.LogError("PlayerInput пуст");
        }

        private void FixedUpdate() {
            
            cameraInput = controller.Move.Movement.ReadValue<Vector2>();
            _rb.MovePosition(_rb.position + (cameraInput * Speed));
        }
    }
}