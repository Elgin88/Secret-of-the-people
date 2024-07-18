using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]

    public class MonsteStaticData : ScriptableObject
    {
        [Range(1, 100)] public int Health;

        [Range(1f, 30f)] public float Damage;
    }
}