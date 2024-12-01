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
    [RequireComponent(typeof(PawnStats))]
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class PawnController : MonoBehaviour
    {
        public Action OnDeath;

        [SerializeField] protected PawnConfig _pawnConfig;

        protected PawnAnimator _pawnAnimator;
        protected PawnCombat _pawnCombat;
        protected PawnEquipment _pawnEquipment;
        protected PawnInteraction _pawnInteraction;
        protected PawnInventory _pawnInventory;
        protected PawnLocomotion _pawnLocomotion;
        protected PawnStats _pawnStats;
        protected FactionConfig _faction;
        protected CircleCollider2D _collider;
        protected Vector2 _moveDirection;
        protected Vector2 _lookDirection;
        protected bool _isFiring;
        public bool CanMove = true;
        public bool CanRotate = true;
        public bool IsPerfomingAction;
        protected bool _isMoving;
        protected bool _isRunning;
        public bool IsInvulnerable;
        protected bool _isDead;
        protected bool _initialized;

        public PawnAnimator PawnAnimator => _pawnAnimator;
        public PawnCombat PawnCombat => _pawnCombat;
        public PawnEquipment PawnEquipment => _pawnEquipment;
        public PawnInteraction PawnInteraction => _pawnInteraction;
        public PawnInventory PawnInventory => _pawnInventory;
        public PawnLocomotion PawnLocomotion => _pawnLocomotion;
        public PawnStats PawnStats => _pawnStats;
        public FactionConfig Faction => _faction;
        public Vector2 MoveDirection => _moveDirection;
        public Vector2 LookDirection => _lookDirection;
        public bool IsRunning => _isRunning;
        public bool IsDead => _isDead;
        public bool Initialized => _initialized;

        public void Initialize(PawnConfig config = null)
        {
            if (config != null)
            {
                _pawnConfig = config;
            }
            GetComponents();
            InitializeComponents();
            _collider.enabled = true;
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
            _pawnStats = GetComponent<PawnStats>();
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
            _pawnStats.Initialize();
            foreach (ItemStack stack in _pawnConfig.StartingItems)
            {
                _pawnInventory.AddItem(stack.Item, stack.Amount);
            }
            _pawnStats.CreateStats();
            foreach (StatModifierCreator modifier in _pawnConfig.StartingStats)
            {
                _pawnStats.AddStatModifier(modifier);
            }
            _faction = _pawnConfig.Faction;
            _pawnEquipment.EquipWeapon(_pawnConfig.Weapon);
            _pawnEquipment.EquipArmor(_pawnConfig.Armor);
        }

        protected virtual void DeinitializeComponents()
        {
            _pawnAnimator.Deinitialize();
            _pawnCombat.Deinitialize();
            _pawnEquipment.Deinitialize();
            _pawnInteraction.Deinitialize();
            _pawnInventory.Deinitialize();
            _pawnLocomotion.Deinitialize();
            _pawnStats.Deinitialize();
        }

        protected virtual void FixedUpdate()
        {
            if (!_initialized)
            {
                return;
            }
            _pawnInteraction.OnFixedUpdate();
            _pawnLocomotion.OnFixedUpdate();
            _pawnStats.OnFixedUpdate();
            if (_isFiring)
            {
                _pawnEquipment.WeaponSlot.Fire();
            }
        }

        public void PerformDeath(PawnController source = null)
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
    }
}