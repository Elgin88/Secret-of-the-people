using Player.Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(HealthChanger))]
    public class DamageTaker : MonoBehaviour, IDamageTaker
    {
        [SerializeField] private HealthChanger _health;

        public void TakeDamage(int damage)
        {
            _health.RemoveCurrentHealth(damage);
        }
    }
}