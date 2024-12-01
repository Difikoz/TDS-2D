using UnityEngine;

namespace WinterUniverse
{
    public class WorldUIManager : MonoBehaviour
    {
        private InventoryBarUI _inventoryBar;
        private InteractableBarUI _interactableBar;
        private Vector2 _screenResolution;

        public InventoryBarUI InventoryBar => _inventoryBar;
        public InteractableBarUI InteractableBar => _interactableBar;
        public Vector2 ScreenResolution => _screenResolution;

        public void Initialize()
        {
            _inventoryBar = GetComponentInChildren<InventoryBarUI>();
            _interactableBar = GetComponentInChildren<InteractableBarUI>();
            _screenResolution = new(Screen.width, Screen.height);
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