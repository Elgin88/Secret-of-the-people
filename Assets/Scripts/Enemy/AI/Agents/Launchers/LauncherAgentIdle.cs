using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentIdle : MonoBehaviour
    {
        [SerializeField] private CheckerIsInAttackRange _checkerIsInAttackRange;
        [SerializeField] private CheckerAgro _checkerAgro;
        [SerializeField] private AgentEdle _agentEdle;

        private void FixedUpdate()
        {
            if (_checkerAgro.IsAgro & _checkerIsInAttackRange.IsAttackRange)
            {
                _agentEdle.On();
            }
            else
            {
                _agentEdle.Off();
            }
        }
    }
}