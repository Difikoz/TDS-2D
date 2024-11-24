using UnityEngine;

namespace WinterUniverse
{
    public class WorldManager : Singleton<WorldManager>
    {
        private PlayerController _player;
        private WorldUIManager _uiManager;

        public PlayerController Player => _player;
        public WorldUIManager UIManager => _uiManager;

        protected override void Awake()
        {
            base.Awake();
            _player = FindFirstObjectByType<PlayerController>();
            _uiManager = GetComponentInChildren<WorldUIManager>();

            _player.Initialize();
            _uiManager.Initialize();
        }

        private void OnDestroy()
        {
            _uiManager.Deinitialize();
            _player.Deinitialize();
        }
    }
}