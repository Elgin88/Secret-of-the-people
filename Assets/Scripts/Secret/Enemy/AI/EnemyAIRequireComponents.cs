using Secret.Enemy.AI.Agents;
using Secret.Enemy.AI.Agents.Checkers;
using Secret.Enemy.AI.Agents.Launchers;
using UnityEngine;

namespace Secret.Enemy.AI
{
    [RequireComponent(typeof(CheckerAgro))]
    [RequireComponent(typeof(CheckerIdle))]
    [RequireComponent(typeof(CheckerIsAttacking))]
    [RequireComponent(typeof(CheckerAttackRange))]
    [RequireComponent(typeof(CheckerIsHit))]
    [RequireComponent(typeof(CkeckerAttackCooldown))]

    [RequireComponent(typeof(LauncherAttack))]
    [RequireComponent(typeof(LauncherIdle))]
    [RequireComponent(typeof(LauncherMoveToPlayer))]
    [RequireComponent(typeof(LauncherPatrol))]

    [RequireComponent(typeof(AgentAttack))]
    [RequireComponent(typeof(AgentEdle))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class EnemyAIRequireComponents : MonoBehaviour { }
}