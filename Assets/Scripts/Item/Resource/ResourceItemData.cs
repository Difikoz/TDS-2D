using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Resource Item", menuName = "Winter Universe/Item/Resource/New Resource Item")]
    public class ResourceItemData : ItemData
    {
        [SerializeField] private ResourceTypeData _resourceType;

        public ResourceTypeData ResourceType => _resourceType;

        public override bool OnUse(PawnController pawn, bool fromInventory = true)
        {
            return false;
        }
    }
}