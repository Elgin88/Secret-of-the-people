using Enemy.Agents.Agents;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgroChecker))]

    public class LauncherMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgroChecker _agroChecker;

        private void Start()
        {
            SubAgro();
            SubNotAgro();
            StopAgent();
        }
        
        private void OnDestroy()
        {
            UnsubAgro();
            UnsubNotAgro();
        }
        
        public void StartAgent()
        {
            _agentMoveToPlayer.Enable();
        }

        public void StopAgent()
        {
            _agentMoveToPlayer.Disable();
        }

        private void OnAgro() => StartAgent();
        private void OnNotAgro() => StopAgent();
        private void SubAgro() => _agroChecker.Agred += OnAgro;
        private void UnsubAgro() => _agroChecker.Agred -= OnAgro;
        private void SubNotAgro() => _agroChecker.NotAgred += OnNotAgro;
        private void UnsubNotAgro() => _agroChecker.NotAgred -= OnNotAgro;
    }
}