using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _shootPoint;

        private PawnController _pawn;
        private WeaponItemData _weaponData;
        private AmmoItemData _ammoData;
        private float _spread;
        private int _ammoInMag;
        private int _ammoInInventory;
        private int _ammoDif;
        private bool _isFiring;
        private bool _isReloading;

        public WeaponItemData WeaponData => _weaponData;
        public AmmoItemData AmmoData => _ammoData;
        public int AmmoInMag => _ammoInMag;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
            _isFiring = false;
            _isReloading = false;
        }

        public void Setup(WeaponItemData data)
        {
            if (data != null)
            {
                _weaponData = data;
                _ammoData = _weaponData.UsingAmmo[0];
                _spriteRenderer.sprite = _weaponData.EquippedSprite;
                _shootPoint.localPosition = _weaponData.ShootPointOffset;
            }
            else
            {
                _weaponData = null;
                _ammoData = null;
                _spriteRenderer.sprite = null;
                _shootPoint.localPosition = Vector3.zero;
            }
            StopAllCoroutines();
            _isFiring = false;
            _isReloading = false;
        }

        public void Fire()
        {
            if (_pawn.IsDead || _isFiring || _isReloading || _weaponData == null)
            {
                return;
            }
            if (_ammoData == null)
            {
                ChangeAmmo();
                return;
            }
            if (_ammoInMag == 0)
            {
                Reload();
                return;
            }
            _isFiring = true;
            if (_weaponData.ConsumeAmmoByShot)
            {
                _ammoInMag--;
            }
            StartCoroutine(FireAction());
        }

        private IEnumerator FireAction()
        {
            WaitForSeconds delay = new(_weaponData.ProjectileDelay);
            for (int i = 0; i < _weaponData.ProjectilePerShot; i++)
            {
                _spread = _shootPoint.eulerAngles.z + Random.Range(-_weaponData.ProjectileSpread, _weaponData.ProjectileSpread);
                Instantiate(_ammoData.ProjectilePrefab, _shootPoint.position, Quaternion.Euler(0f, 0f, _spread)).GetComponent<Projectile>().Launch(_weaponData, _ammoData, _pawn);
                if (_weaponData.ConsumeAmmoByProjectile)
                {
                    _ammoInMag--;
                    if (_ammoInMag == 0)
                    {
                        break;
                    }
                }
                yield return delay;
            }
            yield return new WaitForSeconds(60f / _weaponData.FireRate);
            _isFiring = false;
        }

        public void Reload()
        {
            if (_pawn.IsDead || _isFiring || _isReloading || _weaponData == null)
            {
                return;
            }
            if (_ammoData == null)
            {
                ChangeAmmo();
                return;
            }
            _ammoInInventory = _pawn.PawnInventory.AmountOfItem(_ammoData);
            if (!_weaponData.ConsumeAmmoByReload || _ammoInInventory > 0)
            {
                _isReloading = true;
                StartCoroutine(ReloadAction());
            }
            else
            {
                ChangeAmmo();
            }
        }

        private IEnumerator ReloadAction()
        {
            yield return new WaitForSeconds(_weaponData.ReloadTime);
            if (!_pawn.IsDead && !_isFiring && _weaponData != null && _ammoData != null)
            {
                if (_weaponData.ConsumeAmmoByReload)
                {
                    _ammoDif = _weaponData.MagSize - _ammoInMag;
                    _ammoInInventory = _pawn.PawnInventory.AmountOfItem(_ammoData);
                    if (_ammoDif > _ammoInInventory)
                    {
                        _ammoDif = _ammoInInventory;
                    }
                    _pawn.PawnInventory.RemoveItem(_ammoData, _ammoDif);
                    _ammoInMag += _ammoDif;
                    _ammoInInventory = _pawn.PawnInventory.AmountOfItem(_ammoData);
                }
                else
                {
                    _ammoInMag = _weaponData.MagSize;
                }
            }
            _isReloading = false;
        }

        public void ChangeAmmo()
        {
            if (_pawn.IsDead || _isFiring || _isReloading || _weaponData == null)
            {
                return;
            }
            if (_pawn.PawnInventory.GetAmmo(_weaponData, out AmmoItemData ammo))
            {
                ChangeAmmo(ammo);
            }
        }

        public void ChangeAmmo(AmmoItemData ammo)
        {
            if (_pawn.IsDead || _isFiring || _isReloading)
            {
                return;
            }
            Discharge();
            _ammoData = ammo;
            Reload();
        }

        public void Discharge()
        {
            if (_pawn.IsDead || _isFiring || _isReloading || _weaponData == null || _ammoData == null)
            {
                return;
            }
            if (_weaponData.ConsumeAmmoByReload && _ammoInMag > 0)
            {
                _pawn.PawnInventory.AddItem(_ammoData, _ammoInMag);
            }
            _ammoData = null;
            _ammoInMag = 0;
        }
    }
}