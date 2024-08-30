using System;
using Enemy.Agents.Attack;
using UnityEngine;

namespace Enemy.Agents.Patrol
{
    public class AgentPatrolLauncher : MonoBehaviour
    {
        [SerializeField] private AgentPatrol _agentPatrol;

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