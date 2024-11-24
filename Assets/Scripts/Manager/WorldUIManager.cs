using UnityEngine;

namespace WinterUniverse
{
    public class WorldUIManager : MonoBehaviour
    {
        private InventoryBarUI _inventoryBar;
        private InteractableBarUI _interactableBar;

        public InventoryBarUI InventoryBar => _inventoryBar;
        public InteractableBarUI InteractableBar => _interactableBar;

        public void Initialize()
        {
            _inventoryBar = GetComponentInChildren<InventoryBarUI>();
            _interactableBar = GetComponentInChildren<InteractableBarUI>();

            _inventoryBar.Initialize();
            _interactableBar.Initialize();
        }

        public void Deinitialize()
        {
            _inventoryBar.Deinitialize();
            _interactableBar.Deinitialize();
        }
    }
}