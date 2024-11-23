using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _displayName = "Name";
        [SerializeField, TextArea] private string _description = "Description";
        [SerializeField] private ItemTypeData _itemType;
        [SerializeField] private List<float> _usedByRecipes = new();
        [SerializeField] private Sprite _iconSprite;
        [SerializeField] private Sprite _lootSprite;
        [SerializeField] private int _cost = 100;
        [SerializeField] private float _size = 1f;
        [SerializeField] private float _weight = 1f;

        public string DisplayName => _displayName;
        public string Description => _description;
        public List<float> UsedByRecipes => _usedByRecipes;
        public ItemTypeData ItemType => _itemType;
        public Sprite IconSprite => _iconSprite;
        public Sprite LootSprite => _lootSprite;
        public int Cost => _cost;
        public float Size => _size;
        public float Weight => _weight;
    }
}