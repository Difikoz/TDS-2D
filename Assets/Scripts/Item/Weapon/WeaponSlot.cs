using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _shootPoint;

        private WeaponItemData _weaponData;
        private AmmoItemData _ammoData;
        private float _spread;
        private int _ammoInMag;
        private bool _isFiring;
        private bool _isReloading;

        public WeaponItemData WeaponData => _weaponData;
        public AmmoItemData AmmoData => _ammoData;

        public void Setup(WeaponItemData data)
        {
            if (data != null)
            {
                _weaponData = data;
                _spriteRenderer.sprite = _weaponData.EquippedSprite;
                _shootPoint.localPosition = _weaponData.ShootPointOffset;
            }
            else
            {
                _weaponData = null;
                _spriteRenderer.sprite = null;
                _shootPoint.localPosition = Vector3.zero;
            }
            StopAllCoroutines();
            _isFiring = false;
            _isReloading = false;
        }

        public void Fire()
        {
            if (_isFiring)
            {
                return;
            }
            if (_isReloading)
            {
                return;
            }
            if (_weaponData == null)
            {
                return;
            }
            if (_ammoData == null || _ammoInMag == 0)
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
                Instantiate(_ammoData.ProjectilePrefab, _shootPoint.position, Quaternion.Euler(0f, 0f, _spread)).GetComponent<Projectile>().Launch(_weaponData, _ammoData);
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
            if (_isFiring)
            {
                return;
            }
            if (_isReloading)
            {
                return;
            }
            if (!_weaponData.ConsumeAmmoByReload)//|| have current ammo in inventory
            {
                _isReloading = true;
                StartCoroutine(ReloadAction());
            }
            else
            {
                // check for other ammo
                // if has Reload();
            }
        }

        private IEnumerator ReloadAction()
        {
            yield return new WaitForSeconds(_weaponData.ReloadTime);
            if (_weaponData.ConsumeAmmoByReload)
            {
                // calculate ammo diff
                // if in inventory less, than ammo diff = inventory count
                // remove from inventory
                // add to _ammoInMag
            }
            else
            {
                _ammoInMag = _weaponData.MagSize;
            }
            _isReloading = false;
        }
    }
}