namespace Enemy.Animations
{
    internal interface IAnimationSetter
    {
        public void PlayIdle();

        public void PlayRun();

        public void PlayAttack();

        public void PlayHit();

        public void StopPlayRun();

        public void StopPlayAttack();

        public void StopPlayHit();
    }
}