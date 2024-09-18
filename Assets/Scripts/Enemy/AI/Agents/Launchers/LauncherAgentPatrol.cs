using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentPatrol : MonoBehaviour
    {
        [SerializeField] private CheckerCanHit _checkerCanHit;
        [SerializeField] private CheckerAgro _checkerAgro;
        [SerializeField] private AgentPatrol _agentPatrol;

        private void FixedUpdate()
        {
            if (IsNotAgred() & IsNotCanHit())
            {
                _agentPatrol.On();
            }
            else
            {
                _agentPatrol.Off();
            }
        }

        private bool IsNotCanHit() => !_checkerCanHit.IsCanHit;

        private bool IsNotAgred() => !_checkerAgro.IsAgred;
    }
}