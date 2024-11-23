using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(PawnAnimator))]
    [RequireComponent(typeof(PawnCombat))]
    [RequireComponent(typeof(PawnEquipment))]
    [RequireComponent(typeof(PawnLocomotion))]
    public abstract class PawnController : MonoBehaviour
    {
        protected PawnAnimator _pawnAnimator;
        protected PawnCombat _pawnCombat;
        protected PawnEquipment _pawnEquipment;
        protected PawnLocomotion _pawnLocomotion;
        protected Vector2 _moveDirection;
        protected Vector2 _lookDirection;

        [SerializeField] private float _acceleration = 8f;
        [SerializeField] private float _deceleration = 16f;
        [SerializeField] private float _moveSpeed = 4f;
        [SerializeField] private float _rotateSpeed = 180f;

        public PawnAnimator PawnAnimator => _pawnAnimator;
        public PawnCombat PawnCombat => _pawnCombat;
        public PawnEquipment PawnEquipment => _pawnEquipment;
        public PawnLocomotion PawnLocomotion => _pawnLocomotion;
        public Vector2 MoveDirection => _moveDirection;
        public Vector2 LookDirection => _lookDirection;
        public float Acceleration => _acceleration;
        public float Deceleration => _deceleration;
        public float MoveSpeed => _moveSpeed;
        public float RotateSpeed => _rotateSpeed;

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
            _pawnLocomotion = GetComponent<PawnLocomotion>();
        }

        protected virtual void InitializeComponents()
        {
            _pawnAnimator.Initialize();
            _pawnCombat.Initialize();
            _pawnEquipment.Initialize();
            _pawnLocomotion.Initialize();
        }

        protected virtual void FixedUpdate()
        {
            _pawnLocomotion.OnFixedUpdate();
        }
    }
}