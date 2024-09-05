using Enemy.Agents.Agents;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    public class LauncherAttack : MonoBehaviour
    {
        [SerializeField] private LauncherMoveToPlayer _launcherMoveToPlayer;
        [SerializeField] private CanAttackChecker _canAttackChecker;
        [SerializeField] private LauncherPatrol _launcherPatrol;
        [SerializeField] private AgentAttack _agentAttack;

        private void Awake()
        {
            SubIsCanAttack();
        }

        private void OnDestroy()
        {
            UnsubIsCanAttack();
        }

        public void StartAgent()
        {
        }

        public void StopAgent()
        {
        }

        private void SubIsCanAttack() => _canAttackChecker.IsCanAttack += StartAgent;
        private void UnsubIsCanAttack() => _canAttackChecker.IsCanAttack -= StartAgent;
    }
}