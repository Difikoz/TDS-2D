using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PawnLocomotion : MonoBehaviour
    {
        private PawnController _pawn;
        private Rigidbody2D _rb;
        private Vector2 _moveVelocity;
        private float _requiredLookAngle;
        private float _currentLookAngle;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
            _rb = GetComponent<Rigidbody2D>();
        }

        public void OnFixedUpdate()
        {
            if (_pawn.MoveDirection != Vector2.zero)
            {
                _moveVelocity = Vector2.MoveTowards(_moveVelocity, _pawn.MoveDirection * _pawn.MoveSpeed, _pawn.Acceleration * Time.fixedDeltaTime);
            }
            else
            {
                _moveVelocity = Vector2.MoveTowards(_moveVelocity, Vector2.zero, _pawn.Deceleration * Time.fixedDeltaTime);
            }
            _rb.linearVelocity = _moveVelocity;
            _requiredLookAngle = Mathf.Atan2(_pawn.LookDirection.y, _pawn.LookDirection.x) * Mathf.Rad2Deg;
            _currentLookAngle = Mathf.MoveTowardsAngle(_currentLookAngle, _requiredLookAngle, _pawn.RotateSpeed * Time.fixedDeltaTime);
            _rb.rotation = _currentLookAngle;
        }
    }
}