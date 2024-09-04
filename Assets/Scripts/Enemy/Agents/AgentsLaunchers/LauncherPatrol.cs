using Enemy.Agents.Agents;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    public class LauncherPatrol : MonoBehaviour
    {
        [SerializeField] private AgentPatrol _agentPatrol;

        public void StartAgent()
        {
            _agentPatrol.On();
        }

        public void StopAgent()
        {
            _agentPatrol.Off();
        }
    }
}