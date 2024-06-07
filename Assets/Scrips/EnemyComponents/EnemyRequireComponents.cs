using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(Agro))]
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(EnemyRequireComponents))]

    public class EnemyRequireComponents : MonoBehaviour
    {
    }
}