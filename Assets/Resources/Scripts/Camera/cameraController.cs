using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Assets.Resources.Scripts.Camera
{
    public class cameraController : MonoBehaviour{
        private Vector2 cameraInput;
        private Rigidbody2D _rb;
        [SerializeField] private float Speed;

        private void Awake() {            
            _rb = gameObject.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            
            cameraInput = UnityInputSystem.mainController.Gameplay.MovementCamera.ReadValue<Vector2>();
            _rb.MovePosition(_rb.position + (cameraInput * Speed));
        }
    }
}