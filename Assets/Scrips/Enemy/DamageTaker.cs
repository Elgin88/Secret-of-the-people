using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Enemy
{
    public class DamageTaker : MonoBehaviour, IDamageTaker
    {
        [SerializeField] private HealthSetter _health;

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}