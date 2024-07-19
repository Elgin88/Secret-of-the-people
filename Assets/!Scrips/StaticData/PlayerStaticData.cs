using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "StaticData/Player")]

    public class PlayerStaticData : ScriptableObject
    {
        [Range(1, 100)] public int StartHealth;

        [Range(1, 10)] public float StartRunSpeed;

        [Range(1, 2000)] public int DeltaRotation;

        [Range(0, 1f)] public float HitSpeedCoefficient;

        [Range(0f, 10f)] public float AnimationBaseRunSpeed;
    }
}