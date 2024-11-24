using UnityEngine;

namespace WinterUniverse
{
    public class ItemInteractable : Interactable
    {
        [SerializeField] private ItemData _item;
        [SerializeField] private int _amount = 1;

        public override string GetText()
        {
            return $"Pickup [{_amount}] [<b><color=#{ColorUtility.ToHtmlStringRGBA(_item.Rarity.TextColor)}>{_item.DisplayName}</color></b>]";
        }

        public override void Interact(PawnController pawn)
        {
            Destroy(gameObject);
        }
    }
}