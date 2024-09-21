using Enemy.AI.Agents.Checkers;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherPatrol : MonoBehaviour
    {
        [SerializeField] private AgentPatrol _agentPatrol;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void FixedUpdate()
        {
            if (_checkerAgro.IsAgro)
            {
                _agentPatrol.Off();
            }
            else
            {
                _agentPatrol.On();
            }
        }
    }
}