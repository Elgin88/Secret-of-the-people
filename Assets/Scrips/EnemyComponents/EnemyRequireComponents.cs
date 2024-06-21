using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(AgentAttack))]

    public class EnemyRequireComponents : MonoBehaviour
    {
    }
}