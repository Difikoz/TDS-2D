using UnityEngine;

namespace WinterUniverse
{
    [System.Serializable]
    public class ItemStack
    {
        [SerializeField] private ItemData _item;
        [SerializeField] private int _amount;

        public ItemData Item => _item;
        public int Amount => _amount;

        public ItemStack(ItemData item, int amount = 1)
        {
            _item = item;
            _amount = amount;
        }

        public void AddToStack(int amount = 1)
        {
            _amount += amount;
        }

        public void RemoveFromStack(int amount = 1)
        {
            _amount -= amount;
        }
    }
}