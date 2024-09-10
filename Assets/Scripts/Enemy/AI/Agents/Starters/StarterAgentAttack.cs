using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Starters
{
    public class StarterAgentAttack : MonoBehaviour
    {
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private AgentAttack _agentAttack;

        private void Awake()
        {
            _checkerCanAttack.OnCanAttack += OnCanAttack;
        }

        private void OnDestroy()
        {
            _checkerCanAttack.OnCanAttack -= OnCanAttack;
        }

        private void OnCanAttack()
        {
            _agentAttack.On();
        }
    }
}