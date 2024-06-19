using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Assets.Resources.Scripts.Camera
{
    public class cameraController : MonoBehaviour{
        [SerializeField] private Vector2 cameraInput;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float Speed;
        [SerializeField] private UnityInputSystem inputSystem;

        private void Awake() {
            _rb = gameObject.GetComponent<Rigidbody2D>();
            inputSystem.MovementCameraEvent += OnMovement;
        }

        private void Update() {
            _rb.MovePosition(_rb.position + (cameraInput * Speed));            
        }

        private void OnMovement(Vector2 vector)
        {
            cameraInput = vector;
        }
        private void OnDestroy() {
            _rb = null;
            inputSystem.MovementCameraEvent -= OnMovement;
        }
    }
}