using Enemy.AI.Agents.Checkers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentPatrol : MonoBehaviour
    {
        [SerializeField] private CheckerCanHit _checkerCanHit;
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void FixedUpdate()
        {
            if (!_checkerAgro.IsAgred & !_checkerCanHit.IsCanHit)
            {
                _agentPatrol.On();
            }
            else
            {
                _agentPatrol.Off();
            }
        }
    }
}