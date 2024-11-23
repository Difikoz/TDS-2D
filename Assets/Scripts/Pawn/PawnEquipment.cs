using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnEquipment : MonoBehaviour
    {
        private PawnController _pawn;
        private WeaponSlot _weaponSlot;
        private List<ArmorSlot> _armorSlots = new();

        public WeaponSlot WeaponSlot => _weaponSlot;
        public List<ArmorSlot> ArmorSlots => _armorSlots;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
            _weaponSlot = GetComponentInChildren<WeaponSlot>();
            ArmorSlot[] armorSlots = GetComponentsInChildren<ArmorSlot>();
            foreach (ArmorSlot slot in armorSlots)
            {
                _armorSlots.Add(slot);
            }
        }

        public void EquipWeapon(WeaponItemData data, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (removeNewFromInventory)
            {
                //remove new
            }
            if (_weaponSlot.Data != null)
            {
                if (addOldToInventory)
                {
                    //add old
                }
                //remove stats
            }
            _weaponSlot.Setup(data);
            //add stats
            //OnChanged
        }

        public void UnequipWeapon(bool addOldToInventory)
        {
            if (_weaponSlot.Data != null)
            {
                if (addOldToInventory)
                {
                    //add old
                }
                //remove stats
                _weaponSlot.Setup(null);
                //OnChanged
            }
        }

        public void EquipArmor(ArmorItemData data, bool removeOldFromInventory = true, bool addOldToInventory = true)
        {
            foreach (ArmorSlot slot in _armorSlots)
            {
                if (slot.ArmorType == data.ArmorType)
                {
                    if (removeOldFromInventory)
                    {
                        //remove new
                    }
                    if (slot.Data != null)
                    {
                        if (addOldToInventory)
                        {
                            //add old
                        }
                        // remove stats
                    }
                    slot.Setup(data);
                    //add stats
                    //OnChanged
                    break;
                }
            }
        }

        public void UnequipArmor(ArmorTypeData type, bool addOldToInventory = true)
        {
            foreach (ArmorSlot slot in _armorSlots)
            {
                if (slot.ArmorType == type)
                {
                    if (slot.Data != null)
                    {
                        if (addOldToInventory)
                        {
                            //add old
                        }
                        //remove stats
                        slot.Setup(null);
                    }
                    break;
                }
            }
        }
    }
}