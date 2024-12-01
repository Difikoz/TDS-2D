using System;
using System.Collections.Generic;
using UnityEngine;

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

        public void AddItem(ItemConfig item, int amount = 1)
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

        public void RemoveItem(ItemConfig item, int amount = 1)
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
                    break;
                }
            }
            OnInventoryChanged?.Invoke(_stacks);
        }

        public void DropItem(ItemConfig item, int amount = 1)
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
                    break;
                }
            }
            OnInventoryChanged?.Invoke(_stacks);
        }

        public int AmountOfItem(ItemConfig item)
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

        public bool GetWeapon(out WeaponItemConfig data)
        {
            data = null;
            int rating = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item.ItemType.DisplayName == "Weapon" && stack.Item.Price > rating)
                {
                    data = (WeaponItemConfig)stack.Item;
                    rating = data.Price;
                }
            }
            return data != null;
        }

        public bool GetArmor(out ArmorItemConfig data)
        {
            data = null;
            int rating = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item.ItemType.DisplayName == "Armor" && stack.Item.Price > rating)
                {
                    data = (ArmorItemConfig)stack.Item;
                    rating = data.Price;
                }
            }
            return data != null;
        }

        public bool GetConsumable(ConsumableTypeConfig type, out ConsumableItemConfig data)
        {
            data = null;
            ConsumableItemConfig tempData;
            int rating = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item.ItemType.DisplayName == "Consumable" && stack.Item.Price > rating)
                {
                    tempData = (ConsumableItemConfig)stack.Item;
                    if (tempData.ConsumableType == type)
                    {
                        data = tempData;
                        rating = data.Price;
                    }
                }
            }
            return data != null;
        }

        public bool GetAmmo(WeaponItemConfig weapon, out AmmoItemConfig ammo)
        {
            ammo = null;
            int amount = 0;
            foreach (ItemStack stack in _stacks)
            {
                if (stack.Item.ItemType.DisplayName == "Ammo" && weapon.UsingAmmo.Contains((AmmoItemConfig)stack.Item) && stack.Amount > amount)
                {
                    ammo = (AmmoItemConfig)stack.Item;
                    amount = stack.Amount;
                }
            }
            return ammo != null;
        }
    }
}