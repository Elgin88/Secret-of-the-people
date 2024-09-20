using System;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentPatrol : MonoBehaviour
    {
        [SerializeField] private AgentPatrol _agentPatrol;

        private void Awake()
        {
            _agentPatrol.Off();
        }
    }
}