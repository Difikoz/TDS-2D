using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Animator))]
    public class PawnAnimator : MonoBehaviour
    {
        private PawnController _pawn;
        private Animator _animator;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
            _animator = GetComponent<Animator>();

        }

        public void Deinitialize()
        {

        }

        public void SetFloat(string name, float value)
        {
            _animator.SetFloat(name, value);
        }

        public void SetBool(string name, bool value)
        {
            _animator.SetBool(name, value);
        }

        public void PlayAction(string name, float fadeTime = 0.1f, bool isPerfomingAction = true, bool canMove = false, bool canRotate = false, bool isInvulnerable = false)
        {
            _pawn.IsPerfomingAction = isPerfomingAction;
            _pawn.CanMove = canMove;
            _pawn.CanRotate = canRotate;
            _pawn.IsInvulnerable = isInvulnerable;
            _animator.CrossFade(name, fadeTime);
        }
    }
}