using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Starters
{
    public class StarterAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
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
            if (!_checkerCanAttack.IsCanAttack)
            {
                _checkerCanAttack.On();
                _agentMoveToPlayer.On();
            }
        }
    }
}