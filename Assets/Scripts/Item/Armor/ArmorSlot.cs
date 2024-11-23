using UnityEngine;

namespace WinterUniverse
{
    public class ArmorSlot : MonoBehaviour
    {
        [SerializeField] private ArmorTypeData _armorType;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private ArmorItemData _data;

        public ArmorTypeData ArmorType => _armorType;
        public ArmorItemData Data => _data;

        public void Setup(ArmorItemData data)
        {
            _data = data;
            if (_spriteRenderer != null && _data.EquippedSprite != null)
            {
                _spriteRenderer.sprite = _data.EquippedSprite;
            }
        }
    }
}