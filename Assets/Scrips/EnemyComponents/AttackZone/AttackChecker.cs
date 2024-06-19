using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackChecker : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AttackZone _attackZone;

        private void OnEnable()
        {
            _attackZone.InAttackZoneEnter += OnAttackZoneEnter;
            _attackZone.InAttackZoneExit += OnAttackZoneExit;
        }

        private void OnDisable()
        {
            _attackZone.InAttackZoneEnter -= OnAttackZoneEnter;
            _attackZone.InAttackZoneExit -= OnAttackZoneExit;
        }

        private void OnAttackZoneEnter(Collider collider) => _agentAttack.AgentOn();
        private void OnAttackZoneExit(Collider collider) => _agentAttack.AgentOff();
    }
}