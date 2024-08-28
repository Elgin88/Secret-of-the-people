﻿using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "MonsterStaticData", menuName = "StaticData/Monster")]

    public class MonsterStaticData : ScriptableObject
    {
        [Range(1, 100)] public int StartHealth = 1;

        [Range(1f, 30f)] public int Damage = 30;

        [Range(0f, 10f)] public float AttackRange = 1;

        [Range(0f, 40f)] public int AgroRange = 8;

        [Range(0f, 2f)] public float AttackCooldawn = 0.5f;

        [Range(0f, 2f)] public float RadiusOfHitSphere = 0.5f;

        [Range(1f, 10f)] public float MoveToPlayerSpeed = 2;

        [Range(1f, 5f)] public float PatrolSpeed = 1;

        [Range(0f, 10f)] public int MaxPatrolRange = 10;

        [Range(-10f, 0f)] public int MinPatrolRange = -10;

        [Range(0f, 3f)] public int MinDistanceToPlayer = 2;

        [Range(0f, 3f)] public float MoveAnimationSpeed = 1f;

        [Range(0f, 3f)] public float AttackAnimationSpeed = 1.75f;
    }
}