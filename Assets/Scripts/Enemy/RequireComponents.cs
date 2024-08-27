using Enemy.Animations;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(AnimationSetter))]
    [RequireComponent(typeof(AttackAnimation))]
    [RequireComponent(typeof(HealthChanger))]
    [RequireComponent(typeof(RunAnimation))]
    [RequireComponent(typeof(HitAnimation))]

    public class RequireComponents : MonoBehaviour { }
}