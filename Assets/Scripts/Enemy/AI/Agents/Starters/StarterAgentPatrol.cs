using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Starters
{
    public class StarterAgentPatrol : MonoBehaviour
    {
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake()
        {
            _checkerAgro.OnNotAgred += OnNotAgred;
        }

        private void OnDestroy()
        {
            _checkerAgro.OnNotAgred -= OnNotAgred;
        }

        private void OnNotAgred()
        {
            _agentPatrol.On();
            _checkerCanAttack.Off();
        }
    }
}