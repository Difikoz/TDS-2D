using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Armor Item", menuName = "Winter Universe/Item/Armor/New Armor Item")]
    public class ArmorItemData : ItemData
    {
        [SerializeField] private ArmorTypeData _armorType;
        [SerializeField] private AnimatorOverrideController _controller;
        [SerializeField] private List<float> _resistance = new();

        public ArmorTypeData ArmorType => _armorType;
        public AnimatorOverrideController Controller => _controller;
        public List<float> Resistance => _resistance;
    }
}