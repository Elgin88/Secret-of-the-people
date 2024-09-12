using Enemy.AI.Agents;
using Enemy.AI.Agents.Launchers;
using UnityEngine;

namespace Enemy.AI
{
    [RequireComponent(typeof(LauncherAgentAttack))]
    [RequireComponent(typeof(LauncherAgentMoveToPlayer))]
    [RequireComponent(typeof(LauncherAgentPatrol))]
    [RequireComponent(typeof(AgentAttack))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class EnemyAIRequireComponents : MonoBehaviour { }
}