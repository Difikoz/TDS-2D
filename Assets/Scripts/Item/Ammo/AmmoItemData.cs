using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Ammo Item", menuName = "Winter Universe/Item/Ammo/New Ammo Item")]
    public class AmmoItemData : ItemData
    {
        [SerializeField] private AmmoTypeData _ammoType;
        [SerializeField] private float _damageMultiplier = 1f;
        [SerializeField] private float _forceMultiplier = 1f;
        [SerializeField] private int _pierceCount = 0;

        public AmmoTypeData AmmoType => _ammoType;
        public float DamageMultiplier => _damageMultiplier;
        public float ForceMultiplier => _forceMultiplier;
        public int PierceCount => _pierceCount;
    }
}