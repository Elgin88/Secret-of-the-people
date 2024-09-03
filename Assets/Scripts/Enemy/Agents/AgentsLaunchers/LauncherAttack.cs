using Enemy.Agents.Agents;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    [RequireComponent(typeof(LauncherMoveToPlayer))]
    [RequireComponent(typeof(CanAttackChecker))]
    [RequireComponent(typeof(LauncherPatrol))]
    [RequireComponent(typeof(AgentAttack))]

    public class LauncherAttack : MonoBehaviour
    {
        [SerializeField] private LauncherMoveToPlayer _launcherMoveToPlayer;
        [SerializeField] private CanAttackChecker _canAttackChecker;
        [SerializeField] private LauncherPatrol _launcherPatrol;
        [SerializeField] private AgentAttack _agentAttack;

        private void Start()
        {
            SubIsCanAttack();
            Off();
        }

        private void OnDestroy()
        {
            OnsubIsCanAttack();
        }

        public void On()
        {
        }

        public void Off()
        {
            _agentAttack.Off();
            enabled = false;
        }

        private void SubIsCanAttack() => _canAttackChecker.IsCanAttack += On;
        private void OnsubIsCanAttack() => _canAttackChecker.IsCanAttack -= On;
    }
}