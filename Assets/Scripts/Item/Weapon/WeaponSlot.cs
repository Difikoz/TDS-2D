using UnityEngine;

namespace WinterUniverse
{
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _shootPoint;

        private WeaponItemData _data;

        public WeaponItemData Data => _data;

        public void Setup(WeaponItemData data)
        {
            if (data != null)
            {
                _data = data;
                _spriteRenderer.sprite = _data.EquippedSprite;
                _shootPoint.localPosition = _data.ShootPointOffset;
            }
            else
            {
                _data = null;
                _spriteRenderer.sprite = null;
                _shootPoint.localPosition = Vector3.zero;
            }
        }

        public void Fire()
        {

        }
    }
}