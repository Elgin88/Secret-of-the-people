using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "WeaponStaticData", menuName = "StaticData/WeaponStaticData")]

    public class WeaponStaticData : ScriptableObject
    {
        [Range(0f, 3f)] public float DelayBetweenShoots;

        [Range(0f, 3f)] public float DurationReload;

        [Range(0f, 30f)] public int CountBulletsInClip;
    }
}