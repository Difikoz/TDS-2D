using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class InventoryBarUI : MonoBehaviour
    {
        [SerializeField] private GameObject _bar;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _slotRoot;
        [SerializeField] private GameObject _slotPrefab;

        public void Initialize()
        {
            WorldManager.StaticInstance.Player.PawnInventory.OnInventoryChanged += OnInventoryChanged;
            _closeButton.onClick.AddListener(HideBar);
            HideBar();
        }

        public void Deinitialize()
        {
            WorldManager.StaticInstance.Player.PawnInventory.OnInventoryChanged -= OnInventoryChanged;
            _closeButton.onClick.RemoveListener(HideBar);
        }

        public void ShowBar()
        {
            _bar.SetActive(true);
        }

        public void HideBar()
        {
            _bar.SetActive(false);
        }

        private void OnInventoryChanged(List<ItemStack> stacks)
        {
            while (_slotRoot.childCount > 0)
            {
                Destroy(_slotRoot.GetChild(0).gameObject);
            }
            foreach (ItemStack stack in stacks)
            {
                Instantiate(_slotPrefab, _slotRoot).GetComponent<InventorySlotUI>().Setup(stack);
            }
        }
    }
}