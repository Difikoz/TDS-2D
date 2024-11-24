using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Animator))]
    public class PawnAnimator : MonoBehaviour
    {
        private PawnController _pawn;
        private Animator _animator;

        [SerializeField] private AnimatorOverrideController _testDefaultController;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
            _animator = GetComponent<Animator>();
            _pawn.PawnEquipment.OnEquipmentChanged += OnEquipmentChanged;
        }

        public void Deinitialize()
        {
            _pawn.PawnEquipment.OnEquipmentChanged -= OnEquipmentChanged;
        }

        private void OnEquipmentChanged()
        {
            if (_pawn.PawnEquipment.ArmorSlot.Data != null)
            {
                _animator.runtimeAnimatorController = _pawn.PawnEquipment.ArmorSlot.Data.Controller;
            }
            else
            {
                _animator.runtimeAnimatorController = _testDefaultController;
            }
        }

        public void SetFloat(string name, float value)
        {
            _animator.SetFloat(name, value);
        }

        public void SetBool(string name, bool value)
        {
            _animator.SetBool(name, value);
        }

        public void PlayAction(string name, float fadeTime = 0.1f, bool canMove = false, bool canRotate = false)
        {
            _pawn.ToggleStates(canMove, canRotate);
            _animator.CrossFade(name, fadeTime);
        }
    }
}