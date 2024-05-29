using Scripts.Logic;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(CameraFollower))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerRequireComponents))]

    public class PlayerRequireComponents : MonoBehaviour
    {
    }
}