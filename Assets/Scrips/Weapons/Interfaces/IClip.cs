using Scripts.CodeBase.Logic;

namespace Scripts.Weapons
{
    public interface IClip
    {
        public void RemoveBullet();

        public void Reload();

        public void Construct(IGameFactory iGameFactory);
    }
}