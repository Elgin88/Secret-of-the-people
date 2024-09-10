using Enemy.AI.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Stoppers
{
    public class StopperAgentPatrol : MonoBehaviour
    {
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake()
        {
            _checkerAgro.OnAgred += OnAgred;
            _agentPatrol.Off();
        }

        private void OnDestroy()
        {
            _checkerAgro.OnAgred -= OnAgred;
        }

        private void OnAgred() => _agentPatrol.Off();
    }
}