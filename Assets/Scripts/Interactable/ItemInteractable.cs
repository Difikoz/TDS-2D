using UnityEngine;

namespace WinterUniverse
{
    public class ItemInteractable : Interactable
    {
        [SerializeField] private ItemData _item;
        [SerializeField] private int _amount = 1;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private PolygonCollider2D _collider;

        public void Setup(ItemData item, int amount = 1)
        {
            _item = item;
            _amount = amount;
            _spriteRenderer.sprite = _item.LootSprite;
            if (_collider != null)
            {
                Destroy(_collider);
            }
            _collider = gameObject.AddComponent<PolygonCollider2D>();
            _collider.isTrigger = true;
        }

        public override string GetText()
        {
            return $"[{_amount}] [<b><color=#{ColorUtility.ToHtmlStringRGBA(_item.Rarity.TextColor)}>{_item.DisplayName}</color></b>]\nTap [F] to pick up\nHold [F] to use";
        }

        public override void PrimaryInteraction(PawnController pawn)
        {
            pawn.PawnInventory.AddItem(_item, _amount);
            Destroy(gameObject);
        }

        public override void SecondaryInteraction(PawnController pawn)
        {
            if (_item.OnUse(pawn, false))
            {
                _amount--;
                if (_amount == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}