using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Winter Universe/Crafting/Recipe/New Recipe")]
    public class RecipeConfig : TypeConfig
    {
        [SerializeField] private List<ItemStack> _ingredients = new();
        [SerializeField] private List<ItemStack> _results = new();

        public List<ItemStack> Ingredients => _ingredients;
        public List<ItemStack> Results => _results;
    }
}