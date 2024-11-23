using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Armor Item", menuName = "Winter Universe/Item/Armor/New Armor Item")]
    public class ArmorItemData : ItemData
    {
        [SerializeField] private ArmorTypeData _armorType;
        [SerializeField] private Sprite _equippedSprite;
        [SerializeField] private List<float> _resistance = new();

        public ArmorTypeData ArmorType => _armorType;
        public Sprite EquippedSprite => _equippedSprite;
        public List<float> Resistance => _resistance;
    }
}