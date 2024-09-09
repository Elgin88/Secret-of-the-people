using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Stoppers
{
    public class StopperAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerAttacking _checkerAttacking;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake()
        {
            _checkerAgro.OnNotAgred += OnNotAgred;
            _checkerAttacking.OnAttacking += OnAttacking;
            _agentMoveToPlayer.Off();
        }
        
        private void OnDestroy()
        {
            _checkerAgro.OnNotAgred -= OnNotAgred;
            _checkerAttacking.OnAttacking += OnAttacking;
        }

        private void OnAttacking() => _agentMoveToPlayer.Off();
        private void OnNotAgred() => _agentMoveToPlayer.Off();
    }
}