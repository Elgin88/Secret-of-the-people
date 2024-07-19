using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "MonsterStaticData", menuName = "StaticData/Monster")]

    public class MonsterStaticData : ScriptableObject
    {
        [Range(1, 100)] public int Health;

        [Range(1f, 30f)] public int Damage;

        [Range(1f, 10f)] public float AttackRange;

        [Range(1f, 40f)] public int AgroRange;

        [Range(0f, 2f)] public float AttackCooldawn;

        [Range(0f, 1f)] public float RadiusOfHitSphere;

        [Range(1f, 10f)] public float MoveToPlayerSpeed;

        [Range(1f, 5f)] public float PatrolSpeed;

        [Range(0f, 10f)] public int MaxPatrolRange;

        [Range(-10f, 0f)] public int MinPatrolRange;

        [Range(0f, 3f)] public int MinDistanceToPlayer;
    }
}