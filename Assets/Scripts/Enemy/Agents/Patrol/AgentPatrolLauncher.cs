using Enemy.Agents.Attack;
using UnityEngine;

namespace Enemy.Agents.Patrol
{
    public class AgentPatrolLauncher : MonoBehaviour
    {
        [SerializeField] private AgentAttack _agentAttack;
        [SerializeField] private AgentPatrol _agentPatrol;

        private void Start()
        {
            _agentPatrol.AgentEnable();
            _agentAttack.DisableAgent();
        }
    }
}