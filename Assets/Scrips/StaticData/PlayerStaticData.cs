using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "StaticData/Player")]

    public class PlayerStaticData : ScriptableObject
    {
        [Range(1, 100)] public int StartHealth = 100;

        [Range(1, 10)] public float StarMovementSpeed = 6;

        [Range(1, 2000)] public int RotationSpeed = 2000;

        [Range(0, 1f)] public float CoefficientDownSpeedAfterHit = 0.2f;

        [Range(0f, 10f)] public float AnimationBaseRunSpeed = 4.8f;

        [Range(0f, 20f)] public int RangeToChooserNearestTarget = 10;

        [Range(0f, 10f)] public int StartGunClipsCount = 2;
    }
}