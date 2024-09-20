using System;
using UnityEngine;

namespace Enemy.AI.Agents.Launchers
{
    public class LauncherAgentIdle : MonoBehaviour
    {
        [SerializeField] private AgentEdle _agentEdle;

        private void Awake()
        {
            _agentEdle.On();
        }
    }
}