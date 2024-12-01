using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PawnLocomotion : MonoBehaviour
    {
        private PawnController _pawn;
        private Rigidbody2D _rb;
        private Vector2 _moveVelocity;
        private Vector2 _knockbackVelocity;
        private float _requiredLookAngle;
        private float _currentLookAngle;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Deinitialize()
        {

        }

        public void OnFixedUpdate()
        {
            if (_knockbackVelocity != Vector2.zero)
            {
                _knockbackVelocity = Vector2.MoveTowards(_knockbackVelocity, Vector2.zero, _rb.mass * Time.fixedDeltaTime);
            }
            if (_pawn.MoveDirection != Vector2.zero && _pawn.CanMove)
            {
                _moveVelocity = Vector2.MoveTowards(_moveVelocity, _pawn.MoveDirection * _pawn.PawnStats.MoveSpeed.CurrentValue, _pawn.PawnStats.Acceleration.CurrentValue * Time.fixedDeltaTime);
            }
            else
            {
                _moveVelocity = Vector2.MoveTowards(_moveVelocity, Vector2.zero, _pawn.PawnStats.Deceleration.CurrentValue * Time.fixedDeltaTime);
            }
            _rb.linearVelocity = _moveVelocity + _knockbackVelocity;
            if (_pawn.CanRotate)
            {
                _requiredLookAngle = Mathf.Atan2(_pawn.LookDirection.y, _pawn.LookDirection.x) * Mathf.Rad2Deg;
                _currentLookAngle = Mathf.MoveTowardsAngle(_currentLookAngle, _requiredLookAngle, _pawn.PawnStats.RotateSpeed.CurrentValue * Time.fixedDeltaTime);
                _rb.rotation = _currentLookAngle;
            }
            _pawn.PawnAnimator.SetBool("IsMoving", _moveVelocity != Vector2.zero);
        }

        public void ApplyKnockback(Vector2 direction, float force)
        {
            _knockbackVelocity += direction.normalized * force;
        }
    }
}