using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "WeaponStaticData", menuName = "StaticData/WeaponStaticData")]

    public class EnemyStaticData : ScriptableObject
    {
        [Range(0f, 100f)] public int StartHealth;

        [Range(0f, 3f)] public float DelayBetweenShoots;

        [Range(0f, 3f)] public float DurationReload;

        [Range(0f, 30f)] public int BulletCount;
    }
}