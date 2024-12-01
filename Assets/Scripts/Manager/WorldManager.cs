using UnityEngine;

namespace WinterUniverse
{
    public class WorldManager : Singleton<WorldManager>
    {
        private PlayerController _player;
        private WorldAIManager _aiManager;
        private WorldCameraManager _cameraManager;
        private WorldUIManager _uiManager;
        private WorldConfigsManager _configsManager;

        public PlayerController Player => _player;
        public WorldAIManager AIManager => _aiManager;
        public WorldCameraManager CameraManager => _cameraManager;
        public WorldUIManager UIManager => _uiManager;
        public WorldConfigsManager ConfigsManager => _configsManager;

        protected override void Awake()
        {
            base.Awake();
            _player = FindFirstObjectByType<PlayerController>();
            _aiManager = GetComponentInChildren<WorldAIManager>();
            _cameraManager = GetComponentInChildren<WorldCameraManager>();
            _uiManager = GetComponentInChildren<WorldUIManager>();
            _configsManager = GetComponentInChildren<WorldConfigsManager>();

            _configsManager.Initialize();
            _player.Initialize();
            _aiManager.Initialize();
            _cameraManager.Initialize(_player);
            _uiManager.Initialize();
        }

        private void FixedUpdate()
        {
            _player.OnFixedUpdate();
            _aiManager.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            _cameraManager.OnLateUpdate();
        }

        private void OnDestroy()
        {
            _uiManager.Deinitialize();
            _aiManager.Deinitialize();
            _player.Deinitialize();
        }
    }
}