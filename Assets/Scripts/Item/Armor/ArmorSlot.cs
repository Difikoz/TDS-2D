using UnityEngine;

namespace WinterUniverse
{
    public class ArmorSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private ArmorItemData _data;

        public ArmorItemData Data => _data;

        public void Setup(ArmorItemData data)
        {
            _data = data;
            //if (_spriteRenderer != null && _data.EquippedSprite != null)
            //{
            //    _spriteRenderer.sprite = _data.EquippedSprite;
            //}
        }
    }
}