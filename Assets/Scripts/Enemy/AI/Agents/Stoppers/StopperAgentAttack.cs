using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Stoppers
{
    public class StopperAgentAttack : MonoBehaviour
    {
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private AgentAttack _agentAttack;

        private void Awake()
        {
            _agentAttack.Off();
        }
    }
}