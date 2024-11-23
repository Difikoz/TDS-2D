using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        private WeaponItemData _weapon;
        private AmmoItemData _ammo;

        private int _curPierceCount;

        public void Launch(WeaponItemData weapon, AmmoItemData ammo)
        {
            _weapon = weapon;
            _ammo = ammo;
            _curPierceCount = 0;
            StartCoroutine(DespawnTimer());
            _rb.linearVelocity = transform.right * _weapon.ProjectileForce * _ammo.ForceMultiplier;
        }

        private IEnumerator DespawnTimer()
        {
            yield return new WaitForSeconds(_weapon.Range / _weapon.ProjectileForce * _ammo.ForceMultiplier);
            Despawn();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PawnController pawn))
            {
                pawn.PerformDeath();
                //_weapon.Damage * _ammo.DamageMultiplier
                //_weapon.ProjectileKnockback * _ammo.KnockbackMultiplier
                _curPierceCount++;
                if (_curPierceCount >= _ammo.PierceCount + 1)
                {
                    Despawn();
                }
            }
        }

        private void Despawn()
        {
            _rb.linearVelocity = Vector2.zero;
            Destroy(gameObject);
        }
    }
}