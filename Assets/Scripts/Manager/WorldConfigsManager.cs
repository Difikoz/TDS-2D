using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class WorldConfigsManager : MonoBehaviour
    {
        private List<Stat> _newStats = new();
        private List<ItemConfig> _items = new();

        [SerializeField] private List<StatConfig> _stats = new();
        [SerializeField] private List<FactionConfig> _factions = new();
        [SerializeField] private List<WeaponItemConfig> _weapons = new();
        [SerializeField] private List<AmmoItemConfig> _ammo = new();
        [SerializeField] private List<ArmorItemConfig> _armors = new();
        [SerializeField] private List<ConsumableItemConfig> _consumables = new();
        [SerializeField] private List<ResourceItemConfig> _resources = new();

        public List<StatConfig> Stats => _stats;
        public List<FactionConfig> Factions => _factions;
        public List<ItemConfig> Items => _items;
        public List<WeaponItemConfig> Weapons => _weapons;
        public List<AmmoItemConfig> Ammo => _ammo;
        public List<ArmorItemConfig> Armors => _armors;
        public List<ConsumableItemConfig> Consumables => _consumables;
        public List<ResourceItemConfig> Resources => _resources;

        public void Initialize()
        {
            foreach (StatConfig data in _stats)
            {
                _newStats.Add(new(data));
            }
            foreach (WeaponItemConfig data in _weapons)
            {
                _items.Add(data);
            }
            foreach (ArmorItemConfig data in _armors)
            {
                _items.Add(data);
            }
            foreach (ConsumableItemConfig data in _consumables)
            {
                _items.Add(data);
            }
            foreach (ResourceItemConfig data in _resources)
            {
                _items.Add(data);
            }
        }

        public List<Stat> GetStats()
        {
            return _newStats;
        }

        public StatConfig GetStat(string name)
        {
            foreach (StatConfig data in _stats)
            {
                if (data.DisplayName == name)
                {
                    return data;
                }
            }
            return null;
        }

        public FactionConfig GetFaction(string name)
        {
            foreach (FactionConfig data in _factions)
            {
                if (data.DisplayName == name)
                {
                    return data;
                }
            }
            return null;
        }

        public ItemConfig GetItem(string name)
        {
            foreach (ItemConfig data in _items)
            {
                if (data.DisplayName == name)
                {
                    return data;
                }
            }
            return null;
        }

        public WeaponItemConfig GetWeapon(string name)
        {
            foreach (WeaponItemConfig data in _weapons)
            {
                if (data.DisplayName == name)
                {
                    return data;
                }
            }
            return null;
        }

        public AmmoItemConfig GetAmmo(string name)
        {
            foreach (AmmoItemConfig data in _ammo)
            {
                if (data.DisplayName == name)
                {
                    return data;
                }
            }
            return null;
        }

        public ArmorItemConfig GetArmor(string name)
        {
            foreach (ArmorItemConfig data in _armors)
            {
                if (data.DisplayName == name)
                {
                    return data;
                }
            }
            return null;
        }

        public ConsumableItemConfig GetConsumable(string name)
        {
            foreach (ConsumableItemConfig data in _consumables)
            {
                if (data.DisplayName == name)
                {
                    return data;
                }
            }
            return null;
        }

        public ResourceItemConfig GetResource(string name)
        {
            foreach (ResourceItemConfig data in _resources)
            {
                if (data.DisplayName == name)
                {
                    return data;
                }
            }
            return null;
        }
    }
}