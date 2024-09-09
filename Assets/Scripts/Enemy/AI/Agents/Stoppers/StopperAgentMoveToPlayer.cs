using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Stoppers
{
    public class StopperAgentMoveToPlayer : MonoBehaviour
    {
        [SerializeField] private AgentMoveToPlayer _agentMoveToPlayer;
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake()
        {
            _agentMoveToPlayer.Off();
            _checkerAgro.OnNotAgred += OnNotAgred;
        }

        private void OnNotAgred()
        {
            _checkerCanAttack.Off();
            _agentMoveToPlayer.Off();
        }
    }
}