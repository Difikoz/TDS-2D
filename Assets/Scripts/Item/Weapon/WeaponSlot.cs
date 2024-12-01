using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _shootPoint;

        private PawnController _pawn;
        private WeaponItemConfig _weaponConfig;
        private AmmoItemConfig _ammoConfig;
        private float _spread;
        private int _ammoInMag;
        private int _ammoInInventory;
        private int _ammoDif;
        private bool _isFiring;
        private bool _isReloading;

        public WeaponItemConfig WeaponConfig => _weaponConfig;
        public AmmoItemConfig AmmoConfig => _ammoConfig;
        public int AmmoInMag => _ammoInMag;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
            StopAllCoroutines();
            _isFiring = false;
            _isReloading = false;
        }

        public void Setup(WeaponItemConfig config)
        {
            StopAllCoroutines();
            _isFiring = false;
            _isReloading = false;
            if (config != null)
            {
                _weaponConfig = config;
                _spriteRenderer.sprite = _weaponConfig.EquippedSprite;
                _shootPoint.localPosition = _weaponConfig.ShootPointOffset;
                Reload();
            }
            else
            {
                _weaponConfig = null;
                _ammoConfig = null;
                _spriteRenderer.sprite = null;
                _shootPoint.localPosition = Vector3.zero;
            }
        }

        public void Fire()
        {
            if (_pawn.IsDead || _isFiring || _isReloading || _weaponConfig == null)
            {
                return;
            }
            if (_ammoConfig == null)
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
            if (_weaponConfig.ConsumeAmmoByShot)
            {
                _ammoInMag--;
            }
            StartCoroutine(FireAction());
        }

        private IEnumerator FireAction()
        {
            if (_weaponConfig.ProjectileDelay > 0f)
            {
                WaitForSeconds delay = new(_weaponConfig.ProjectileDelay);
                for (int i = 0; i < _weaponConfig.ProjectilePerShot; i++)
                {
                    _spread = _shootPoint.eulerAngles.z + Random.Range(-_weaponConfig.ProjectileSpread, _weaponConfig.ProjectileSpread);
                    Instantiate(_ammoConfig.ProjectilePrefab, _shootPoint.position, Quaternion.Euler(0f, 0f, _spread)).GetComponent<Projectile>().Launch(_weaponConfig, _ammoConfig, _pawn);
                    if (_weaponConfig.ConsumeAmmoByProjectile)
                    {
                        _ammoInMag--;
                        if (_ammoInMag == 0)
                        {
                            break;
                        }
                    }
                    yield return delay;
                }
            }
            else
            {
                for (int i = 0; i < _weaponConfig.ProjectilePerShot; i++)
                {
                    _spread = _shootPoint.eulerAngles.z + Random.Range(-_weaponConfig.ProjectileSpread, _weaponConfig.ProjectileSpread);
                    Instantiate(_ammoConfig.ProjectilePrefab, _shootPoint.position, Quaternion.Euler(0f, 0f, _spread)).GetComponent<Projectile>().Launch(_weaponConfig, _ammoConfig, _pawn);
                    if (_weaponConfig.ConsumeAmmoByProjectile)
                    {
                        _ammoInMag--;
                        if (_ammoInMag == 0)
                        {
                            break;
                        }
                    }
                }
            }
            yield return new WaitForSeconds(60f / _weaponConfig.FireRate);
            _isFiring = false;
        }

        public void Reload()
        {
            if (_pawn.IsDead || _isFiring || _isReloading || _weaponConfig == null)
            {
                return;
            }
            if (_ammoConfig == null)
            {
                ChangeAmmo();
                return;
            }
            _ammoInInventory = _pawn.PawnInventory.AmountOfItem(_ammoConfig);
            if (!_weaponConfig.ConsumeAmmoByReload || _ammoInInventory > 0)
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
            yield return new WaitForSeconds(_weaponConfig.ReloadTime);
            if (!_pawn.IsDead && !_isFiring && _weaponConfig != null && _ammoConfig != null)
            {
                if (_weaponConfig.ConsumeAmmoByReload)
                {
                    _ammoDif = _weaponConfig.MagSize - _ammoInMag;
                    _ammoInInventory = _pawn.PawnInventory.AmountOfItem(_ammoConfig);
                    if (_ammoDif > _ammoInInventory)
                    {
                        _ammoDif = _ammoInInventory;
                    }
                    _pawn.PawnInventory.RemoveItem(_ammoConfig, _ammoDif);
                    _ammoInMag += _ammoDif;
                    _ammoInInventory = _pawn.PawnInventory.AmountOfItem(_ammoConfig);
                }
                else
                {
                    _ammoInMag = _weaponConfig.MagSize;
                }
            }
            _isReloading = false;
        }

        public void ChangeAmmo()
        {
            if (_pawn.IsDead || _isFiring || _isReloading || _weaponConfig == null)
            {
                return;
            }
            if (_pawn.PawnInventory.GetAmmo(_weaponConfig, out AmmoItemConfig ammo))
            {
                ChangeAmmo(ammo);
            }
        }

        public void ChangeAmmo(AmmoItemConfig config)
        {
            if (_pawn.IsDead || _isFiring || _isReloading)
            {
                return;
            }
            Discharge();
            _ammoConfig = config;
            Reload();
        }

        public void Discharge()
        {
            if (_pawn.IsDead || _isFiring || _isReloading || _weaponConfig == null || _ammoConfig == null)
            {
                return;
            }
            if (_weaponConfig.ConsumeAmmoByReload && _ammoInMag > 0)
            {
                _pawn.PawnInventory.AddItem(_ammoConfig, _ammoInMag);
            }
            _ammoConfig = null;
            _ammoInMag = 0;
        }
    }
}