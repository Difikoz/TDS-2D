using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Armor Item", menuName = "Winter Universe/Item/Armor/New Armor Item")]
    public class ArmorItemConfig : ItemConfig
    {
        [SerializeField] private ArmorTypeConfig _armorType;
        [SerializeField] private Sprite _equippedSprite;
        [SerializeField] private List<float> _resistance = new();

        public ArmorTypeConfig ArmorType => _armorType;
        public Sprite EquippedSprite => _equippedSprite;
        public List<float> Resistance => _resistance;

        public override bool OnUse(PawnController pawn, bool fromInventory = true)
        {
            pawn.PawnEquipment.EquipArmor(this, fromInventory);
            return true;
        }
    }
}