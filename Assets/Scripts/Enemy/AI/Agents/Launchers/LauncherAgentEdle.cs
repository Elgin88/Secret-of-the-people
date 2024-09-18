using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentEdle : MonoBehaviour
    {
        [SerializeField] private CheckerAttackEnded _checkerEndHit;
        [SerializeField] private AgentEdle _agentEdle;

        private void FixedUpdate()
        {
            if (_checkerEndHit.IsAttackEnded)
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