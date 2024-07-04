using UnityEngine;

namespace Scripts.Static
{
    public static class StaticLayersNames
    {
        private static string _player = "Player";
        private static int _enemyAgro = LayerMask.NameToLayer("EnemyAgro");
        private static int _enemyAttack = LayerMask.NameToLayer("EnemyAttack");

        public static string Player => _player;
        public static int EnemyAgro => _enemyAgro;
        public static int EnemyAttack => _enemyAttack;
    }
}