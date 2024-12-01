using UnityEngine;

namespace WinterUniverse
{
    public class WorldCameraManager : MonoBehaviour
    {
        private Transform _target;
        private PawnController _pawn;
        private Vector3 _aimOffset;

        [SerializeField] private float _followSpeed = 10f;

        public void Initialize(Transform target)
        {
            _target = target;
            _pawn = null;
        }

        public void Initialize(PawnController pawn)
        {
            _pawn = pawn;
            _target = null;
        }

        public void OnLateUpdate()
        {
            if (_target != null)
            {
                transform.position = Vector3.Lerp(transform.position, _target.position, _followSpeed * Time.deltaTime);
            }
            else if (_pawn != null)
            {
                if (_pawn.IsAiming && _pawn.PawnEquipment.WeaponSlot.WeaponConfig != null)
                {
                    _aimOffset = _pawn.transform.right * Mathf.InverseLerp(0f, _pawn.PawnEquipment.WeaponSlot.WeaponConfig.Range, Vector3.Distance(_pawn.transform.position, _pawn.AimPosition)) * _pawn.PawnEquipment.WeaponSlot.WeaponConfig.Range;
                }
                else
                {
                    _aimOffset = _pawn.transform.right;
                }
                transform.position = Vector3.Lerp(transform.position, _pawn.transform.position + _aimOffset, _followSpeed * Time.deltaTime);
            }
        }
    }
}