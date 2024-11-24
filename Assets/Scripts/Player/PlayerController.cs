using UnityEngine;
using UnityEngine.InputSystem;

namespace WinterUniverse
{
    public class PlayerController : PawnController
    {
        private Vector2 _moveInput;
        private Vector2 _lookInput;

        public void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        public void OnLook(InputValue value)
        {
            _lookInput = value.Get<Vector2>();
        }

        public void OnInteract()
        {
            _pawnInteraction.Interact();
        }

        protected override void FixedUpdate()
        {
            _moveDirection = _moveInput;
            _lookDirection = (Camera.main.ScreenToWorldPoint(_lookInput) - transform.position).normalized;
            base.FixedUpdate();
        }
    }
}