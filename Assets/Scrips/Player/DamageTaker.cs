using UnityEngine;

namespace Scripts.Player
{
    public class DamageTaker : MonoBehaviour, IDamageTaker
    {
        [SerializeField] private HealthChanger _health;

        public void TakeDamage(int damage)
        {
            _health.RemoveCurrentHealth(damage);
        }
    }
}