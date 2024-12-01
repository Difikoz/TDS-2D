using UnityEngine;

namespace WinterUniverse
{
    public class TypeConfig : ScriptableObject
    {
        [SerializeField] private string _displayName = "Name";
        [SerializeField] private Color _textColor = Color.white;
        [SerializeField] private Sprite _iconSprite;

        public string DisplayName => _displayName;
        public Color TextColor => _textColor;
        public Sprite IconSprite => _iconSprite;
    }
}