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
        [SerializeField] private LauncherPatrol _launcherPatrol;
        [SerializeField] private CanAttackChecker _canAttackChecker;
        [SerializeField] private AgentAttack _agentAttack;

        private void Awake()
        {
            SubIsCanAttack();
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
        }

        private void SubIsCanAttack() => _canAttackChecker.IsCanAttack += On;
        private void OnsubIsCanAttack() => _canAttackChecker.IsCanAttack -= On;
    }
}