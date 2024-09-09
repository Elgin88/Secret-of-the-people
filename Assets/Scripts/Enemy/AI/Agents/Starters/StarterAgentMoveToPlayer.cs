using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Starters
{
    public class StarterAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake()
        {
            _checkerAgro.OnAgred += OnAgred;
        }

        private void OnDestroy()
        {
            _checkerAgro.OnAgred -= OnAgred;
        }

        private void OnAgred()
        {
            _agentMoveToPlayer.On();
        }
    }
}