using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Consumable Item", menuName = "Winter Universe/Item/Consumable/New Consumable Item")]
    public class ConsumableItemConfig : ItemConfig
    {
        [SerializeField] private ConsumableTypeConfig _consumableType;
        [SerializeField] private List<float> _effects = new();

        public ConsumableTypeConfig ConsumableType => _consumableType;
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