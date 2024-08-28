using UnityEngine;

namespace Player
{
    public static class PlayerStatic
    {
        public static readonly int DeathAHash = Animator.StringToHash("DeathA");

        public static readonly int DeathBHash = Animator.StringToHash("DeathB");

        public static readonly int DeathCHash = Animator.StringToHash("DeathC");

        public static readonly int DeathDHash = Animator.StringToHash("DeathD");

        public static readonly int DeathEHash = Animator.StringToHash("DeathE");

        public static readonly int IsRunHash = Animator.StringToHash("IsRun");

        public static readonly int IsHitHash = Animator.StringToHash("IsHit");

        public static readonly int RunHash = Animator.StringToHash("Run");
    }
}