using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(EnemyMover))]
    [RequireComponent(typeof(EnemyRequireComponents))]

    public class EnemyRequireComponents : MonoBehaviour
    {
    }
}