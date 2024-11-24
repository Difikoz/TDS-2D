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
        private PawnController _pawn;

        private int _curPierceCount;

        public void Launch(WeaponItemData weapon, AmmoItemData ammo, PawnController pawn)
        {
            _weapon = weapon;
            _ammo = ammo;
            _pawn = pawn;
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
            PawnController pawn = collision.GetComponentInParent<PawnController>();
            if (pawn != null)
            {
                pawn.PawnLocomotion.ApplyKnockback(transform.right, _weapon.ProjectileKnockback * _ammo.KnockbackMultiplier);
                pawn.TakeDamage(_weapon.Damage * _ammo.DamageMultiplier, _pawn);
            }
            _curPierceCount++;
            if (_curPierceCount >= _ammo.PierceCount + 1)
            {
                Despawn();
            }
        }

        private void Despawn()
        {
            _rb.linearVelocity = Vector2.zero;
            Destroy(gameObject);
        }
    }
}