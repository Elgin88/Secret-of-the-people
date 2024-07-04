using UnityEngine;

namespace Scripts.Static
{
    public static class StaticLayersNames
    {
        public static readonly string Player = "Player";
        public static readonly int EnemyAgro = LayerMask.NameToLayer("EnemyAgro");
        public static readonly int EnemyAttack = LayerMask.NameToLayer("EnemyAttack");
    }
}