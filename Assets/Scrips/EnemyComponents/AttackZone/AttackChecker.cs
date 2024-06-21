using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackChecker : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AttackZone _attackZone;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private void OnEnable()
        {
            Subscriptions();
            DisableAttack();
        }

        private void OnDisable()
        {
            Unsubscriptions();
        }

        private void OnPlayerEnter(Collider collider)
        {
            DisableMove();
            EnableAttack();
        }

        private void OnPlayerExit(Collider collider)
        {
            DisableAttack();
            EnableMove();
        }

        private void Subscriptions()
        {
            _attackZone.PlayerEnter += OnPlayerEnter;
            _attackZone.PlayerExit += OnPlayerExit;
        }

        private void Unsubscriptions()
        {
            _attackZone.PlayerEnter -= OnPlayerEnter;
            _attackZone.PlayerExit -= OnPlayerExit;
        }

        private void EnableAttack() => _agentAttack.EnableAgent();
        private void DisableAttack() => _agentAttack.DisableAgent();
        private void DisableMove() => _agentMoveToPlayer.DisableAgent();
        private void EnableMove() => _agentMoveToPlayer.EnableAgent();
    }
}