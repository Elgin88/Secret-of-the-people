using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Stoppers
{
    public class StopperAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerCanAttack _checkerCanAttack;

        private void Awake()
        {
            _agentMoveToPlayer.Off();
            _checkerCanAttack.OnCanAttack += OnCanAttack;
        }

        private void OnDestroy()
        {
            _checkerCanAttack.OnCanAttack -= OnCanAttack;
        }

        private void OnCanAttack() => _agentMoveToPlayer.Off();
    }
}