using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Weapon Item", menuName = "Winter Universe/Item/Weapon/New Weapon Item")]
    public class WeaponItemData : ItemData
    {
        [SerializeField] private WeaponTypeData _weaponType;
        [SerializeField] private Sprite _equippedSprite;
        [SerializeField] private Vector3 _shootPointOffset;
        [SerializeField] private float _damage = 10f;
        [SerializeField] private float _fireRate = 60f;
        [SerializeField] private float _range = 25f;
        [SerializeField] private float _reloadTime = 1f;
        [SerializeField] private bool _consumeAmmoByShot = true;
        [SerializeField] private bool _consumeAmmoByProjectile = false;
        [SerializeField] private bool _consumeAmmoByReload = true;
        [SerializeField] private List<AmmoItemData> _usingAmmo = new();
        [SerializeField] private int _magSize = 1;
        [SerializeField] private int _projectilePerShot = 1;
        [SerializeField] private float _projectileDelay = 0.01f;
        [SerializeField] private float _projectileForce = 25f;
        [SerializeField] private float _projectileKnockback = 2f;
        [SerializeField] private float _projectileSpread = 5f;

        public WeaponTypeData WeaponType => _weaponType;
        public Sprite EquippedSprite => _equippedSprite;
        public Vector3 ShootPointOffset => _shootPointOffset;
        public float Damage => _damage;
        public float FireRate => _fireRate;
        public float Range => _range;
        public float ReloadTime => _reloadTime;
        public bool ConsumeAmmoByShot => _consumeAmmoByShot;
        public bool ConsumeAmmoByProjectile => _consumeAmmoByProjectile;
        public bool ConsumeAmmoByReload => _consumeAmmoByReload;
        public List<AmmoItemData> UsingAmmo => _usingAmmo;
        public int MagSize => _magSize;
        public int ProjectilePerShot => _projectilePerShot;
        public float ProjectileDelay => _projectileDelay;
        public float ProjectileForce => _projectileForce;
        public float ProjectileKnockback => _projectileKnockback;
        public float ProjectileSpread => _projectileSpread;

        public override bool OnUse(PawnController pawn, bool fromInventory = true)
        {
            pawn.PawnEquipment.EquipWeapon(this, fromInventory);
            return true;
        }
    }
}