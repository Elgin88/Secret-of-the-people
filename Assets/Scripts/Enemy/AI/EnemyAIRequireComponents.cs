using Enemy.AI.Agents;
using Enemy.AI.Agents.Starters;
using Enemy.AI.Agents.Stoppers;
using UnityEngine;

namespace Enemy.AI
{
    [RequireComponent(typeof(StarterAgentAttack))]
    [RequireComponent(typeof(StarterAgentMoveToPlayer))]
    [RequireComponent(typeof(StarterAgentPatrol))]
    [RequireComponent(typeof(StopperAgentAttack))]
    [RequireComponent(typeof(StopperAgentMoveToPlayer))]
    [RequireComponent(typeof(StopperAgentPatrol))]
    [RequireComponent(typeof(AgentAttack))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class EnemyAIRequireComponents : MonoBehaviour { }
}