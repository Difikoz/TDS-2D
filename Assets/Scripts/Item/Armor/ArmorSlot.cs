using UnityEngine;

namespace WinterUniverse
{
    public class ArmorSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private PolygonCollider2D _collider;

        private PawnController _pawn;
        private ArmorItemData _data;

        public ArmorItemData Data => _data;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
            _collider = GetComponentInChildren<PolygonCollider2D>();
        }

        public void Setup(ArmorItemData data)
        {
            _data = data;
            if (_collider != null)
            {
                Destroy(_collider);
            }
            _collider = _spriteRenderer.gameObject.AddComponent<PolygonCollider2D>();
            _collider.isTrigger = true;
            //if (_spriteRenderer != null && _data.EquippedSprite != null)
            //{
            //    _spriteRenderer.sprite = _data.EquippedSprite;
            //}
        }
    }
}