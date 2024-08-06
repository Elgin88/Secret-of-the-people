using UnityEngine;

namespace Scripts.Static
{
    public static class StaticLayersNames
    {
        public static readonly int Player = LayerMask.NameToLayer("Player");

        public static readonly int Enemy = LayerMask.NameToLayer("Enemy");

        public static readonly int EnemyAgro = LayerMask.NameToLayer("EnemyAgro");

        public static readonly int EnemyAttack = LayerMask.NameToLayer("EnemyAttack");
    }
}