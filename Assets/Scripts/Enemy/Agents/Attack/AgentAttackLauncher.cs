using Enemy.Agents.MoveToPlayer;
using Enemy.Agents.Patrol;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(TargetChecker))]
    [RequireComponent(typeof(AgentAttack))]

    public class AgentAttackLauncher : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private TargetChecker _findTargetChecker;
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AgentPatrol _agentPatrol;

        private void Awake() => SubTargetFound();

        private void OnDestroy() => UnsubTargetFound();

        public void AgentOn()
        {
            _agentMoveToPlayer.DisableAgent();
            _agentAttack.EnableAgent();
        }

        public void AgentOff()
        {
            _agentAttack.DisableAgent();
            _agentMoveToPlayer.EnableAgent();
        }

        private void SubTargetFound() => _findTargetChecker.IsTargetFound += AgentOn;
        private void UnsubTargetFound() => _findTargetChecker.IsTargetFound -= AgentOn;
    }
}