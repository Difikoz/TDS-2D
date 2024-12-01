using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class InventorySlotUI : MonoBehaviour, ISubmitHandler, IPointerClickHandler
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _text;

        private ItemConfig _item;

        public void OnPointerClick(PointerEventData eventData)
        {
            _item.OnUse(WorldManager.StaticInstance.Player);
        }

        public void OnSubmit(BaseEventData eventData)
        {
            _item.OnUse(WorldManager.StaticInstance.Player);
        }

        public void Setup(ItemStack stack)
        {
            _item = stack.Item;
            _icon.sprite = _item.IconSprite;
            _text.text = $"{_item.DisplayName} x{stack.Amount}";
        }
    }
}