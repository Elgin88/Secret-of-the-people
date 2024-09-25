using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "MonsterStaticData", menuName = "StaticData/Monster")]

    public class MonsterStaticData : ScriptableObject
    {
        [Range(1, 100)] public int StartHealth = 1;

        [Range(1f, 30f)] public int Damage = 30;

        [Range(0f, 2f)] public float AttackCooldown = 0.75f;

        [Range(1f, 40f)] public int AgroRange = 8;

        [Range(1f, 10f)] public float MoveToPlayerSpeed = 2;

        [Range(1f, 5f)] public float PatrolSpeed = 1;

        [Range(1f, 4f)] public float AttackRange = 2.5f;

        [Range(0f, 3f)] public float RunAnimationSpeed = 0.9f;

        [Range(0f, 3f)] public float AttackAnimationSpeed = 1.75f;
    }
}