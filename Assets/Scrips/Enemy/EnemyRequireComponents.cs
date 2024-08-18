using UnityEngine;

namespace Scripts.Enemy
{
    [RequireComponent(typeof(DamageTaker))]
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(HealthSetter))]

    public class EnemyRequireComponents : MonoBehaviour
    {
    }
}