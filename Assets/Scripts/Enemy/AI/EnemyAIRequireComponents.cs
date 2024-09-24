using Enemy.AI.Agents;
using Enemy.AI.Agents.Checkers;
using Enemy.AI.Agents.Launchers;
using UnityEngine;

namespace Enemy.AI
{
    [RequireComponent(typeof(CheckerAgro))]
    [RequireComponent(typeof(CheckerIdle))]
    [RequireComponent(typeof(CheckerIsAttacking))]
    [RequireComponent(typeof(CheckerAttackRange))]
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