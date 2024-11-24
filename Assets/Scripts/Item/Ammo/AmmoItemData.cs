using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Ammo Item", menuName = "Winter Universe/Item/Ammo/New Ammo Item")]
    public class AmmoItemData : ItemData
    {
        [SerializeField] private AmmoTypeData _ammoType;
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private float _damageMultiplier = 1f;
        [SerializeField] private float _forceMultiplier = 1f;
        [SerializeField] private float _knockbackMultiplier = 1f;
        [SerializeField] private int _pierceCount = 0;

        public AmmoTypeData AmmoType => _ammoType;
        public GameObject ProjectilePrefab => _projectilePrefab;
        public float DamageMultiplier => _damageMultiplier;
        public float ForceMultiplier => _forceMultiplier;
        public float KnockbackMultiplier => _knockbackMultiplier;
        public int PierceCount => _pierceCount;

        public override bool OnUse(PawnController pawn, bool fromInventory = true)
        {
            if (!fromInventory)
            {
                return false;
            }
            pawn.PawnEquipment.WeaponSlot.ChangeAmmo(this);
            return true;
        }
    }
}