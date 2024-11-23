using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnEquipment : MonoBehaviour
    {
        public Action OnEquipmentChanged;

        private PawnController _pawn;
        private WeaponSlot _weaponSlot;
        private ArmorSlot _armorSlot;

        public WeaponSlot WeaponSlot => _weaponSlot;
        public ArmorSlot ArmorSlot => _armorSlot;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
            _weaponSlot = GetComponentInChildren<WeaponSlot>();
            _armorSlot = GetComponentInChildren<ArmorSlot>();
            _pawn.OnDeath += DropWeapon;
        }

        public void Deinitialize()
        {
            _pawn.OnDeath -= DropWeapon;
        }

        public void EquipWeapon(WeaponItemData data, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (removeNewFromInventory)
            {
                //remove new
            }
            if (_weaponSlot.WeaponData != null)
            {
                if (addOldToInventory)
                {
                    //add old
                }
                //remove stats
            }
            _weaponSlot.Setup(data);
            //add stats
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipWeapon(bool addOldToInventory)
        {
            if (_weaponSlot.WeaponData != null)
            {
                if (addOldToInventory)
                {
                    //add old
                }
                //remove stats
                _weaponSlot.Setup(null);
                OnEquipmentChanged?.Invoke();
            }
        }

        public void DropWeapon()
        {
            if (_weaponSlot.WeaponData != null)
            {
                //remove stats
                //drop
                // or add to inventory and drop throw inventory
                _weaponSlot.Setup(null);
                OnEquipmentChanged?.Invoke();
            }
        }

        public void EquipArmor(ArmorItemData data, bool removeOldFromInventory = true, bool addOldToInventory = true)
        {
            if (removeOldFromInventory)
            {
                //remove new
            }
            if (_armorSlot.Data != null)
            {
                if (addOldToInventory)
                {
                    //add old
                }
                //remove stats
            }
            _armorSlot.Setup(data);
            //add stats
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipArmor(bool addOldToInventory = true)
        {
            if (_armorSlot.Data != null)
            {
                if (addOldToInventory)
                {
                    //add old
                }
                //remove stats
                _armorSlot.Setup(null);
                OnEquipmentChanged?.Invoke();
            }
        }
    }
}