using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Stoppers
{
    public class StopperAgentAttack : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private CheckerCanAttack _checkerCanAttack;

        private void Awake()
        {
            _checkerCanAttack.OnNotCanAttack += OnCanNotAttack;
            _agentAttack.Off();
        }

        private void OnDestroy()
        {
            _checkerCanAttack.OnNotCanAttack += OnCanNotAttack;
        }

        private void OnCanNotAttack()
        {
            _agentAttack.Off();
        }
    }
}