using Enemy.AI.Agents;
using UnityEngine;

namespace Enemy.AI
{
    [RequireComponent(typeof(AgentEdle))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentPatrol))]

    public class EnemyAIRequireComponents : MonoBehaviour { }
}