using UnityEngine;

namespace WinterUniverse
{
    public class ArmorSlot : MonoBehaviour
    {
        private PawnController _pawn;
        private ArmorItemConfig _config;
        private SpriteRenderer _spriteRenderer;

        public ArmorItemConfig Config => _config;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void Setup(ArmorItemConfig config)
        {
            _config = config;
            if (_config != null && _config.EquippedSprite != null)
            {
                _spriteRenderer.sprite = _config.EquippedSprite;
            }
            else
            {
                _spriteRenderer.sprite = null;
            }
        }
    }
}