using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerChooserNearestTarget))]
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(PlayerHit))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerShooter))]

    public class PlayerRequireComponents : MonoBehaviour
    {
    }
}