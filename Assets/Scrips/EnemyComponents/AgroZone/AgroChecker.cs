using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgroChecker : MonoBehaviour
    {
        [SerializeField] private AgroZone _agroTrigger;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;

        private void OnEnable()
        {
            _agroTrigger.TriggeredEnter += OnTriggerEnter;
            _agroTrigger.TriggeredExit += OnTriggerExit;
        }

        private void OnDisable()
        {
            _agroTrigger.TriggeredEnter -= OnTriggerEnter;
            _agroTrigger.TriggeredExit -= OnTriggerExit;
        }

        private void OnTriggerEnter(Collider collider)
        {
            AgentMoveToPlayerOn();
        }

        private void OnTriggerExit(Collider collider)
        {
            AgentMoveToPlayerOff();
        }

        private void AgentMoveToPlayerOn() => _agentMoveToPlayer.AgentOn();
        private void AgentMoveToPlayerOff() => _agentMoveToPlayer.AgentOff();
    }
}