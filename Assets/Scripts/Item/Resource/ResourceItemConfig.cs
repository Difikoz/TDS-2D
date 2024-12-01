using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Resource Item", menuName = "Winter Universe/Item/Resource/New Resource Item")]
    public class ResourceItemConfig : ItemConfig
    {
        [SerializeField] private ResourceTypeConfig _resourceType;

        public ResourceTypeConfig ResourceType => _resourceType;

        public override bool OnUse(PawnController pawn, bool fromInventory = true)
        {
            return false;
        }
    }
}