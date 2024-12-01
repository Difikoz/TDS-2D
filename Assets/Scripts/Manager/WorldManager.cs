using UnityEngine;

namespace WinterUniverse
{
    public class WorldManager : Singleton<WorldManager>
    {
        private PlayerController _player;
        private WorldUIManager _uiManager;
        private WorldConfigsManager _configsManager;

        public PlayerController Player => _player;
        public WorldUIManager UIManager => _uiManager;
        public WorldConfigsManager ConfigsManager => _configsManager;

        protected override void Awake()
        {
            base.Awake();
            _player = FindFirstObjectByType<PlayerController>();
            _uiManager = GetComponentInChildren<WorldUIManager>();
            _configsManager = GetComponentInChildren<WorldConfigsManager>();

            _configsManager.Initialize();
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