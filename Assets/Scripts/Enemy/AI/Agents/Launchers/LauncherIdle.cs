using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherIdle : MonoBehaviour
    {
        [SerializeField] private CheckerIsInAttackRange _checkerIsInAttackRange;
        [SerializeField] private CheckerAgro _checkerAgro;
        [SerializeField] private CheckerIdle _checkerIdle;
        [SerializeField] private AgentEdle _agentEdle;

        private void FixedUpdate()
        {
            if (_checkerAgro.IsAgro & _checkerIsInAttackRange.IsInAttackRange & _checkerIdle.IsIdle)
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