using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerCameraFollower))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerRequireComponents))]

    public class PlayerRequireComponents : MonoBehaviour
    {
    }
}