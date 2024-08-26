using Player.Interfaces;
using UnityEngine;

namespace Player
{
    public class DamageTaker : MonoBehaviour, IDamageTaker
    {
        [SerializeField] private HealthChanger _health;
        [SerializeField] private HitTaker _hitTaker;

        public void TakeDamage(int damage)
        {
            _health.RemoveCurrentHealth(damage);
            _hitTaker.Hit();
        }
    }
}