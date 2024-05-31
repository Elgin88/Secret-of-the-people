using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(EnemyRequireComponents))]

    public class EnemyRequireComponents : MonoBehaviour
    {
    }
}