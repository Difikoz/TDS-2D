using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace WinterUniverse
{
    public class PawnInventory : MonoBehaviour
    {
        public Action<List<ItemStack>> OnInventoryChanged;

        private PawnController _pawn;
        private List<ItemStack> _stacks = new();

        public List<ItemStack> Stacks => _stacks;

        public void Initialize()
        {
            _pawn = GetComponent<PawnController>();
        }

        public void Deinitialize()
        {

        }

        public void AddItem(ItemData item, int amount = 1)
        {
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item == item)
                {
                    stack.AddToStack(amount);
                    amount = 0;
                    break;
                }
            }
            if (amount > 0)
            {
                _stacks.Add(new(item, amount));
            }
            OnInventoryChanged?.Invoke(_stacks);
        }

        public void RemoveItem(ItemData item, int amount = 1)
        {
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item == item)
                {
                    if (stack.Amount > amount)
                    {
                        stack.RemoveFromStack(amount);
                    }
                    else
                    {
                        _stacks.Remove(stack);
                    }
                    amount = 0;
                    break;
                }
            }
            OnInventoryChanged?.Invoke(_stacks);
        }

        public void DropItem(ItemData item, int amount = 1)
        {
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item == item)
                {
                    if (stack.Amount > amount)
                    {
                        stack.RemoveFromStack(amount);
                    }
                    else
                    {
                        _stacks.Remove(stack);
                    }
                    // spawn item
                    amount = 0;
                    break;
                }
            }
            OnInventoryChanged?.Invoke(_stacks);
        }

        public int AmountOfItem(ItemData item)
        {
            int amount = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item == item)
                {
                    amount += stack.Amount;
                }
            }
            return amount;
        }

        public bool GetWeapon(out WeaponItemData data)
        {
            data = null;
            int rating = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item.ItemType.DisplayName == "Weapon" && stack.Item.Price > rating)
                {
                    data = (WeaponItemData)stack.Item;
                    rating = data.Price;
                }
            }
            return data != null;
        }

        public bool GetArmor(out ArmorItemData data)
        {
            data = null;
            int rating = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item.ItemType.DisplayName == "Armor" && stack.Item.Price > rating)
                {
                    data = (ArmorItemData)stack.Item;
                    rating = data.Price;
                }
            }
            return data != null;
        }

        public bool GetConsumable(ConsumableTypeData type, out ConsumableItemData data)
        {
            data = null;
            ConsumableItemData tempData;
            int rating = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item.ItemType.DisplayName == "Consumable" && stack.Item.Price > rating)
                {
                    tempData = (ConsumableItemData)stack.Item;
                    if (tempData.ConsumableType == type)
                    {
                        data = tempData;
                        rating = data.Price;
                    }
                }
            }
            return data != null;
        }

        public bool GetAmmo(WeaponItemData weapon, out AmmoItemData ammo)
        {
            ammo = null;
            int amount = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item.ItemType.DisplayName == "Ammo" && weapon.UsingAmmo.Contains((AmmoItemData)stack.Item) && stack.Amount > amount)
                {
                    ammo = (AmmoItemData)stack.Item;
                    amount = stack.Amount;
                }
            }
            return ammo != null;
        }
    }
}