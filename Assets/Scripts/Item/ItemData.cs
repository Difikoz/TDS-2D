using UnityEngine;

namespace WinterUniverse
{
    public abstract class ItemData : ScriptableObject
    {
        [SerializeField] private string _displayName = "Name";
        [SerializeField, TextArea] private string _description = "Description";
        [SerializeField] private RarityData _rarity;
        [SerializeField] private ItemTypeData _itemType;
        [SerializeField] private Sprite _iconSprite;
        [SerializeField] private Sprite _lootSprite;
        [SerializeField] private bool _usableFromGround = true;
        [SerializeField] private int _price = 100;
        [SerializeField] private float _size = 1f;
        [SerializeField] private float _weight = 1f;

        public string DisplayName => _displayName;
        public string Description => _description;
        public RarityData Rarity => _rarity;
        public ItemTypeData ItemType => _itemType;
        public Sprite IconSprite => _iconSprite;
        public Sprite LootSprite => _lootSprite;
        public bool UsableFromGround => _usableFromGround;
        public int Price => _price;
        public float Size => _size;
        public float Weight => _weight;

        public abstract bool OnUse(PawnController pawn, bool fromInventory = true);
    }
}