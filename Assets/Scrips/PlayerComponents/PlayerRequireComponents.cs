using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerAnimation))]
    [RequireComponent(typeof(PlayerCameraFollower))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(PlayerRequireComponents))]

    public class PlayerRequireComponents : MonoBehaviour
    {
    }
}