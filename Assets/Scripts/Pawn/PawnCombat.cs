using UnityEngine;

namespace WinterUniverse
{
    public class PawnCombat : MonoBehaviour
    {
        private PawnController _pawn;
        private PawnController _target;

        public PawnController Target => _target;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
        }

        public void SetTarget(PawnController target)
        {
            if (target != null)
            {
                _target = target;
            }
            else
            {
                _target = null;
            }
        }
    }
}