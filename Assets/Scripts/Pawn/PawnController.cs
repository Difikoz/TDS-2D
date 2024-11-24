using System;
using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(PawnAnimator))]
    [RequireComponent(typeof(PawnCombat))]
    [RequireComponent(typeof(PawnEquipment))]
    [RequireComponent(typeof(PawnInteraction))]
    [RequireComponent(typeof(PawnInventory))]
    [RequireComponent(typeof(PawnLocomotion))]
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class PawnController : MonoBehaviour
    {
        public Action OnDeath;

        protected PawnAnimator _pawnAnimator;
        protected PawnCombat _pawnCombat;
        protected PawnEquipment _pawnEquipment;
        protected PawnInteraction _pawnInteraction;
        protected PawnInventory _pawnInventory;
        protected PawnLocomotion _pawnLocomotion;
        protected CircleCollider2D _collider;
        protected Vector2 _moveDirection;
        protected Vector2 _lookDirection;
        protected bool _isFiring;
        protected bool _canMove = true;
        protected bool _canRotate = true;
        protected bool _isDead;
        protected bool _initialized;

        protected float _healthCurrent;
        protected float _energyCurrent;

        [SerializeField] private float _acceleration = 8f;
        [SerializeField] private float _deceleration = 16f;
        [SerializeField] private float _moveSpeed = 4f;
        [SerializeField] private float _rotateSpeed = 180f;
        [SerializeField] private float _healthMax = 100f;
        [SerializeField] private float _energyMax = 100f;

        public PawnAnimator PawnAnimator => _pawnAnimator;
        public PawnCombat PawnCombat => _pawnCombat;
        public PawnEquipment PawnEquipment => _pawnEquipment;
        public PawnInteraction PawnInteraction => _pawnInteraction;
        public PawnInventory PawnInventory => _pawnInventory;
        public PawnLocomotion PawnLocomotion => _pawnLocomotion;
        public Vector2 MoveDirection => _moveDirection;
        public Vector2 LookDirection => _lookDirection;
        public bool CanMove => _canMove;
        public bool CanRotate => _canRotate;
        public bool IsDead => _isDead;
        public bool Initialized => _initialized;
        public float Acceleration => _acceleration;
        public float Deceleration => _deceleration;
        public float MoveSpeed => _moveSpeed;
        public float RotateSpeed => _rotateSpeed;
        public float HealthMax => _healthMax;
        public float EnergyMax => _energyMax;

        public void Initialize()
        {
            GetComponents();
            InitializeComponents();
            _healthCurrent = _healthMax;// test
            _isDead = false;
            _initialized = true;
        }

        public void Deinitialize()
        {
            _initialized = false;
            DeinitializeComponents();
        }

        protected virtual void GetComponents()
        {
            _pawnAnimator = GetComponent<PawnAnimator>();
            _pawnCombat = GetComponent<PawnCombat>();
            _pawnEquipment = GetComponent<PawnEquipment>();
            _pawnInteraction = GetComponent<PawnInteraction>();
            _pawnInventory = GetComponent<PawnInventory>();
            _pawnLocomotion = GetComponent<PawnLocomotion>();
            _collider = GetComponent<CircleCollider2D>();
        }

        protected virtual void InitializeComponents()
        {
            _pawnAnimator.Initialize();
            _pawnCombat.Initialize();
            _pawnEquipment.Initialize();
            _pawnInteraction.Initialize();
            _pawnInventory.Initialize();
            _pawnLocomotion.Initialize();
            _collider.enabled = true;
        }

        protected virtual void DeinitializeComponents()
        {
            _pawnAnimator.Deinitialize();
            _pawnCombat.Deinitialize();
            _pawnEquipment.Deinitialize();
            _pawnInteraction.Deinitialize();
            _pawnInventory.Deinitialize();
            _pawnLocomotion.Deinitialize();
        }

        protected virtual void FixedUpdate()
        {
            if (!_initialized)
            {
                return;
            }
            _pawnInteraction.OnFixedUpdate();
            _pawnLocomotion.OnFixedUpdate();
            if (_isFiring)
            {
                _pawnEquipment.WeaponSlot.Fire();
            }
        }

        public void PerformDeath()
        {
            if (_isDead)
            {
                return;
            }
            _isDead = true;
            _pawnAnimator.PlayAction("Death");
            OnDeath?.Invoke();
            _collider.enabled = false;
            StartCoroutine(ProcessDeath());
        }

        protected virtual IEnumerator ProcessDeath()
        {
            yield return new WaitForSeconds(5f);
            Deinitialize();
            yield return null;
            Destroy(gameObject);
        }

        public void TakeDamage(float value, PawnController source = null)
        {
            if (_isDead)
            {
                return;
            }
            _healthCurrent = Mathf.Clamp(_healthCurrent - value, 0f, _healthMax);
            if (_healthCurrent <= 0f)
            {
                PerformDeath();
            }
        }

        public void RestoreHealth(float value)
        {
            if (_isDead)
            {
                return;
            }
            _healthCurrent = Mathf.Clamp(_healthCurrent + value, 0f, _healthMax);
        }

        public void ToggleStates(bool canMove, bool canRotate)
        {
            _canMove = canMove;
            _canRotate = canRotate;
        }
    }
}