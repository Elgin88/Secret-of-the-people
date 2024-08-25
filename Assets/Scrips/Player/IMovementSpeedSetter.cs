namespace Scripts.Player
{
    public interface IMovementSpeedSetter
    {
        public void SetCurrentSpeed(float speed);

        public void SetCurrentHitSpeed(float speed, float duration);
    }
}