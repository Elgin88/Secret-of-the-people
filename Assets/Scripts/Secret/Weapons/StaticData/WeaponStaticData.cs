using UnityEngine;

namespace Secret.Weapons.StaticData
{
    [CreateAssetMenu(fileName = "WeaponStaticData", menuName = "StaticData/WeaponStaticData")]

    public class WeaponStaticData : ScriptableObject
    {
        [Range(0f, 3f)] public float DelayBetweenShoots = 0.5f;

        [Range(0f, 3f)] public float DurationReload = 1;

        [Range(0f, 30f)] public int BulletCount = 8;
    }
}