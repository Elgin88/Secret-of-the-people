﻿using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "WeaponStaticData", menuName = "StaticData/WeaponStaticData")]

    public class EnemyStaticData : ScriptableObject
    {
        [Range(0f, 100f)] public int MaxHealth = 1;

        [Range(0f, 3f)] public float DelayBetweenShoots = 0.5f;

        [Range(0f, 3f)] public float DurationReload = 1;

        [Range(0f, 30f)] public int BulletCount = 8;
    }
}