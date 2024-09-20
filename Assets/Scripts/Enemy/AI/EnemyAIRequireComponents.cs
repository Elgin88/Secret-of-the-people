using Enemy.AI.Agents;
using Enemy.AI.Agents.Launchers;
using UnityEngine;

namespace Enemy.AI
{
    [RequireComponent(typeof(LauncherAgentIdle))]
    [RequireComponent(typeof(LauncherAgentMoveToPlayer))]
    [RequireComponent(typeof(LauncherAgentPatrol))]
    
    [RequireComponent(typeof(AgentEdle))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class EnemyAIRequireComponents : MonoBehaviour { }
}