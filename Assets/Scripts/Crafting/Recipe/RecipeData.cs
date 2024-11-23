using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Winter Universe/Crafting/Recipe/New Recipe")]
    public class RecipeData : ScriptableObject
    {
        [SerializeField] private string _displayName = "Name";
        [SerializeField] private Color _textColor = Color.white;
        [SerializeField] private Sprite _iconSprite;
        [SerializeField] private List<ItemStack> _ingredients = new();
        [SerializeField] private List<ItemStack> _results = new();

        public string DisplayName => _displayName;
        public Color TextColor => _textColor;
        public Sprite IconSprite => _iconSprite;
        public List<ItemStack> Ingredients => _ingredients;
        public List<ItemStack> Results => _results;
    }
}