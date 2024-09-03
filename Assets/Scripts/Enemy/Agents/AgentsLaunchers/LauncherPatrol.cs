using Enemy.Agents.Agents;
using UnityEngine;

namespace Enemy.Agents.AgentsLaunchers
{
    public class LauncherPatrol : MonoBehaviour
    {
        [SerializeField] private AgentPatrol _agentPatrol;

        private void Start()
        {
            On();
        }

        private void OnEnable()
        {
            _agentPatrol.On();
        }

        private void OnDisable()
        {
            _agentPatrol.Off();
        }

        public void On()
        {
            enabled = true;
        }

        public void Off()
        {
            enabled = false;
        }
    }
}