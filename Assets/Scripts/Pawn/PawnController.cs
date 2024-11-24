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
    public abstract class PawnController : MonoBehaviour
    {
        public Action OnDeath;

        protected PawnAnimator _pawnAnimator;
        protected PawnCombat _pawnCombat;
        protected PawnEquipment _pawnEquipment;
        protected PawnInteraction _pawnInteraction;
        protected PawnInventory _pawnInventory;
        protected PawnLocomotion _pawnLocomotion;
        protected Vector2 _moveDirection;
        protected Vector2 _lookDirection;
        protected bool _isDead;

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
        public bool IsDead => _isDead;
        public float Acceleration => _acceleration;
        public float Deceleration => _deceleration;
        public float MoveSpeed => _moveSpeed;
        public float RotateSpeed => _rotateSpeed;
        public float HealthMax => _healthMax;
        public float EnergyMax => _energyMax;

        private void Awake()
        {
            GetComponents();
            InitializeComponents();
        }

        protected virtual void GetComponents()
        {
            _pawnAnimator = GetComponent<PawnAnimator>();
            _pawnCombat = GetComponent<PawnCombat>();
            _pawnEquipment = GetComponent<PawnEquipment>();
            _pawnInteraction = GetComponent<PawnInteraction>();
            _pawnInventory = GetComponent<PawnInventory>();
            _pawnLocomotion = GetComponent<PawnLocomotion>();
        }

        protected virtual void InitializeComponents()
        {
            _pawnAnimator.Initialize();
            _pawnCombat.Initialize();
            _pawnEquipment.Initialize();
            _pawnInteraction.Initialize();
            _pawnInventory.Initialize();
            _pawnLocomotion.Initialize();
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
            _pawnInteraction.OnFixedUpdate();
            _pawnLocomotion.OnFixedUpdate();
        }

        public void PerformDeath()
        {
            if (_isDead)
            {
                return;
            }
            _isDead = true;
            OnDeath?.Invoke();
            StartCoroutine(ProcessDeath());
        }

        protected virtual IEnumerator ProcessDeath()
        {
            yield return new WaitForSeconds(5f);
            DeinitializeComponents();
            yield return null;
            Destroy(gameObject);
        }
    }
}