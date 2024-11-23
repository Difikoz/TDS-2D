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
        [SerializeField] private bool _consumeAmmo = true;
        [SerializeField] private List<AmmoItemData> _usingAmmo = new();
        [SerializeField] private int _bulletPerShot = 1;
        [SerializeField] private float _bulletForce = 25f;
        [SerializeField] private float _bulletSpread = 5f;

        public WeaponTypeData WeaponType => _weaponType;
        public Sprite EquippedSprite => _equippedSprite;
        public Vector3 ShootPointOffset => _shootPointOffset;
        public float Damage => _damage;
        public float FireRate => _fireRate;
        public float Range => _range;
        public bool ConsumeAmmo => _consumeAmmo;
        public List<AmmoItemData> UsingAmmo => _usingAmmo;
        public int BulletPerShot => _bulletPerShot;
        public float BulletForce => _bulletForce;
        public float BulletSpread => _bulletSpread;
    }
}