using UnityEngine;

namespace WinterUniverse
{
    public class ArmorSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private PawnController _pawn;
        private ArmorItemConfig _config;

        public ArmorItemConfig Config => _config;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
        }

        public void Setup(ArmorItemConfig config)
        {
            _config = config;
            if (_spriteRenderer != null && _config.EquippedSprite != null)
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