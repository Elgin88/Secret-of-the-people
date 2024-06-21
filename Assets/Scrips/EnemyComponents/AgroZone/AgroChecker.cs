using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgroChecker : MonoBehaviour
    {
        [SerializeField] private AgroZone _agroTrigger;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private void OnEnable()
        {
            DisableMove();
            Subscriptions();
        }

        private void OnDisable() => Unsubscriptions();

        private void Subscriptions()
        {
            _agroTrigger.TriggeredEnter += OnPlayerEnter;
            _agroTrigger.TriggeredExit += OnPlayerExit;
        }

        private void Unsubscriptions()
        {
            _agroTrigger.TriggeredEnter -= OnPlayerEnter;
            _agroTrigger.TriggeredExit -= OnPlayerExit;
        }


        private void OnPlayerEnter(Collider collider) => EnableMove();
        private void OnPlayerExit(Collider collider) => DisableMove();
        private void EnableMove() => _agentMoveToPlayer.EnableAgent();
        private void DisableMove() => _agentMoveToPlayer.DisableAgent();
    }
}