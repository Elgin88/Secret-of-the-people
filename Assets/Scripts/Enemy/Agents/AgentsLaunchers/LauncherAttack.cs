using Enemy.Agents.Agents;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    [RequireComponent(typeof(LauncherMoveToPlayer))]
    [RequireComponent(typeof(CanAttacker))]
    [RequireComponent(typeof(LauncherPatrol))]
    [RequireComponent(typeof(AgentAttack))]

    public class LauncherAttack : MonoBehaviour
    {
        private LauncherMoveToPlayer _launcherMoveToPlayer;
        private LauncherPatrol _launcherPatrol;
        private CanAttacker _canAttacker;
        private AgentAttack _agentAttack;

        private void Awake()
        {
            GetComponents();
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

        private void SubIsCanAttack() => _canAttacker.IsCanAttack += On;
        private void OnsubIsCanAttack() => _canAttacker.IsCanAttack -= On;

        private void GetComponents()
        {
            _launcherMoveToPlayer = GetComponent<LauncherMoveToPlayer>();
            _canAttacker = GetComponent<CanAttacker>();
            _launcherPatrol = GetComponent<LauncherPatrol>();
            _agentAttack = GetComponent<AgentAttack>();
        }
    }
}