using System;
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

        public void On()
        {
            _agentPatrol.On();
            enabled = true;
        }

        public void Off()
        {
            _agentPatrol.Off();
            enabled = false;
        }
    }
}