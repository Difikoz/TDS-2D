using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class WorldAIManager : MonoBehaviour
    {
        [SerializeField] private List<AIController> _startingAI = new();

        private List<AIController> _allAI = new();

        public void Initialize()
        {
            foreach (AIController ai in _startingAI)
            {
                ai.Initialize();
                _allAI.Add(ai);
            }
        }

        public void Deinitialize()
        {
            foreach (AIController ai in _allAI)
            {
                ai.Deinitialize();
            }
            _allAI.Clear();
        }

        public void OnFixedUpdate()
        {
            for (int i = _allAI.Count - 1; i >= 0; i--)
            {
                if (_allAI[i].IsDead)
                {
                    _allAI[i].Deinitialize();
                    _allAI.RemoveAt(i);
                }
                else
                {
                    _allAI[i].OnFixedUpdate();
                }
            }
        }
    }
}