using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Starters
{
    public class StarterAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private CheckerAgro _checkerAgro;
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerCanAttack _checkerCanAttack;

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
            _checkerCanAttack.On();
            _agentMoveToPlayer.On();
        }
    }
}