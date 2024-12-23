using UnityEngine;

namespace WinterUniverse
{
    public class WorldCameraManager : MonoBehaviour
    {
        private Transform _target;
        private PawnController _pawn;
        private Vector3 _aimOffset;

        [SerializeField] private float _followSpeed = 10f;
        [SerializeField] private float _aimSpeed = 5f;

        public void Initialize(Transform target)
        {
            _target = target;
            _pawn = null;
        }

        public void Initialize(PawnController pawn)
        {
            _pawn = pawn;
            _target = _pawn.transform;
        }

        public void OnLateUpdate()
        {
            if (_target != null)
            {
                transform.position = Vector3.Lerp(transform.position, _target.position, _followSpeed * Time.deltaTime);
            }
            if (_pawn != null)
            {
                if (_pawn.IsAiming && _pawn.PawnEquipment.WeaponSlot.WeaponConfig != null)
                {
                    _aimOffset = _pawn.transform.right * _pawn.AimMagnitude * _pawn.PawnEquipment.WeaponSlot.WeaponConfig.Range;
                    transform.position = Vector3.Lerp(transform.position, _pawn.transform.position + _aimOffset, _aimSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, _pawn.transform.position, _followSpeed * Time.deltaTime);
                }
            }
        }
    }
}