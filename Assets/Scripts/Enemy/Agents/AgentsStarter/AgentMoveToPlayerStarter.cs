using Enemy.Agents.Agents;
using Enemy.Agents.AgentsCheckers;
using UnityEngine;

namespace Enemy.Agents.AgentsStarter
{
    public class AgentMoveToPlayerStarter : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private AgroChecker _agroChecker;

        private void Awake()
        {
            _agroChecker.Agred += OnAgred;
        }

        private void OnDestroy()
        {
            _agroChecker.Agred -= OnAgred;
        }

        private void OnAgred()
        {
            if (!_agentMoveToPlayer.enabled)
            {
                _agentMoveToPlayer.On();
            }
        }
    }
}