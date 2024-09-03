using Enemy.Agents.Agents;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(CanAttackChecker))]
    [RequireComponent(typeof(LauncherPatrol))]
    [RequireComponent(typeof(AgroChecker))]

    public class LauncherMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CanAttackChecker _canAttackChecker;
        [SerializeField] private LauncherPatrol _launcherPatrol;
        [SerializeField] private AgroChecker _agroChecker;

        private void Start()
        {
            SubAgro();
            Off();
        }

        private void OnDestroy()
        {
            UnsubAgro();
        }

        public void On()
        {
            _agentMoveToPlayer.On();
            _canAttackChecker.On();
            _launcherPatrol.Off();
        }

        public void Off()
        {
            _agentMoveToPlayer.Off();
            _canAttackChecker.Off();
            _launcherPatrol.On();
        }

        private void OnAgro() => On();
        private void SubAgro() => _agroChecker.Agred += OnAgro;
        private void UnsubAgro() => _agroChecker.Agred -= OnAgro;
    }
}