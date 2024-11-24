using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Consumable Item", menuName = "Winter Universe/Item/Consumable/New Consumable Item")]
    public class ConsumableItemData : ItemData
    {
        [SerializeField] private ConsumableTypeData _consumableType;
        [SerializeField] private List<float> _effects = new();

        public ConsumableTypeData ConsumableType => _consumableType;
        public List<float> Effects => _effects;

        public override bool OnUse(PawnController pawn, bool fromInventory = true)
        {
            if (fromInventory)
            {
                pawn.PawnInventory.RemoveItem(this);
            }
            // apply effects
            return true;
        }
    }
}