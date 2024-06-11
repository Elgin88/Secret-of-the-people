using System.Collections;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(AgentMoveToPlayer))]

    public class Agro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        private const int _delayToStopMove = 1;
        private AgentMoveToPlayer _agentMoveToPlayer;
        private Coroutine _agentOffAfterDelay;

        private void OnEnable()
        {
            GetComponents();

            _triggerObserver.TriggeredEnter += OnTriggerEnter;
            _triggerObserver.TriggeredExit += OnTriggerExit;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggeredEnter -= OnTriggerEnter;
            _triggerObserver.TriggeredExit -= OnTriggerExit;
        }

        private void OnTriggerEnter(Collider collider)
        {
            AgentMoveToPlayerOn();
            StopSwitchFollowAfterCooldawn();
        }

        private void OnTriggerExit(Collider collider)
        {
            if (_agentOffAfterDelay == null)
            {
                _agentOffAfterDelay = StartCoroutine(SwitchFollowAfterCooldown());
            }
        }

        private void GetComponents() => _agentMoveToPlayer = GetComponent<AgentMoveToPlayer>();
        private void AgentMoveToPlayerOn() => _agentMoveToPlayer.AgentOn();
        private void AgentMoveToPlayerOff() => _agentMoveToPlayer.AgentOff();

        private IEnumerator SwitchFollowAfterCooldown()
        {
            yield return new WaitForSeconds(_delayToStopMove);
            AgentMoveToPlayerOff();
        }

        private void StopSwitchFollowAfterCooldawn()
        {
            if (_agentOffAfterDelay != null)
            {
                StopCoroutine(_agentOffAfterDelay);
                _agentOffAfterDelay = null;
            }
        }
    }
}