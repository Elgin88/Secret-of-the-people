using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(Agro))]
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(EnemyRequireComponents))]
    [RequireComponent(typeof(Attack))]

    public class EnemyRequireComponents : MonoBehaviour
    {
    }
}