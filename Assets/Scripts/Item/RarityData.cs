using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Rarity", menuName = "Winter Universe/Item/New Rarity")]
    public class RarityData : ScriptableObject
    {
        [SerializeField] private string _displayName = "Name";
        [SerializeField] private Color _textColor = Color.white;

        public string DisplayName => _displayName;
        public Color TextColor => _textColor;
    }
}