using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Pawn", menuName = "Winter Universe/Pawn/New Pawn")]
    public class PawnConfig : ScriptableObject
    {
        public string CharacterName = "Name";
        public FactionConfig Faction;
        public WeaponItemConfig Weapon;
        public ArmorItemConfig Armor;
        public List<ItemStack> StartingItems = new();
        public List<StatModifierCreator> StartingStats = new();
    }
}