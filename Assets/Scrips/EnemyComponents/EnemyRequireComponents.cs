using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(AgentMoveToPlayer))]
    [RequireComponent(typeof(EnemyRequireComponents))]
    [RequireComponent(typeof(Agro))]

    public class EnemyRequireComponents : MonoBehaviour
    {
    }
}