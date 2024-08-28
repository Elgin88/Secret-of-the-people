namespace Enemy.Animations
{
    internal interface IEnemyAnimationSetter
    {
        public void PlayRun();

        public void PlayAttack();

        public void PlayHit();

        public void StopPlayRun();

        public void StopPlayAttack();

        public void StopPlayHit();
    }
}