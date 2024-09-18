using Enemy.AI.Agents;
using Enemy.AI.Agents.Checkers;
using Enemy.AI.Agents.Launchers;
using UnityEngine;

namespace Enemy.AI
{
    [RequireComponent(typeof(CheckerAgro))]
    [RequireComponent(typeof(CheckerCanHit))]
    [RequireComponent(typeof(CheckerAttackEnded))]

    [RequireComponent(typeof(LauncherAgentAttack))]
    [RequireComponent(typeof(LauncherAgentEdle))]
    [RequireComponent(typeof(LauncherAgentMoveToPlayer))]
    [RequireComponent(typeof(LauncherAgentPatrol))]

    [RequireComponent(typeof(AgentAttack))]
    [RequireComponent(typeof(AgentEdle))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class EnemyAIRequireComponents : MonoBehaviour { }
}