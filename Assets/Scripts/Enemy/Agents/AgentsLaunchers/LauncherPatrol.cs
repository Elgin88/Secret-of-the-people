using Enemy.Agents.Agents;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    public class LauncherPatrol : MonoBehaviour
    {
        private AgentPatrol _agentPatrol;

        private void Start()
        {
            SetComponents();
            On();
        }

        private void On()
        {
            _agentPatrol.On();
        }

        private void Off()
        {
            _agentPatrol.Off();
        }

        private void SetComponents() => _agentPatrol = GetComponent<AgentPatrol>();
    }
}