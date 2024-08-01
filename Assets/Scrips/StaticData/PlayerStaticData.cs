using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "StaticData/Player")]

    public class PlayerStaticData : ScriptableObject
    {
        [Range(1, 100)] public int Health;

        [Range(1, 10)] public float RunSpeed;

        [Range(1, 2000)] public int RotationSpeed;

        [Range(0, 1f)] public float CoefficientDownSpeedAfterHit;

        [Range(0f, 10f)] public float AnimationBaseRunSpeed;

        [Range(0f, 20f)] public int RangeToChooserNearestTarget;
    }
}