using System;
using Enemy.Agents.Attack;
using UnityEngine;

namespace Enemy.Agents.Patrol
{
    public class AgentPatrolLauncher : MonoBehaviour
    {
        private AgentPatrol _agentPatrol;

        private void Awake()
        {
            _agentPatrol = GetComponent<AgentPatrol>();
        }

        public void AgentOn()
        {

        }

        public void AgentOff()
        {
        }

        private void Start()
        {
            _agentPatrol.AgentEnable();
        }
    }
}