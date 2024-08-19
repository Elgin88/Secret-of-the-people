using UnityEngine;

namespace Scripts.Enemy
{
    [RequireComponent(typeof(DamageTaker))]
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(HealthChanger))]

    public class RequireComponents : MonoBehaviour { }
}