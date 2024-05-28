using UnityEngine;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(EnemyRequireComponents))]

    public class EnemyRequireComponents : MonoBehaviour
    {
        private static readonly int _run = Animator.StringToHash("IsMove");
    }
}