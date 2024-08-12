using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunBullet : MonoBehaviour, IBullet
    {
        [SerializeField] private BulletStaticData _staticData;
        [SerializeField] private GunBulletMover _gunBulletMover;

        private IGameFactory _iGameFactory;

        private float _startSpeed;

        public float Speed => _startSpeed;

        public void Construct(IGameFactory gameFactory)
        {
            SetIGameFactory(gameFactory);
            SetStartSpeed();
        }

        public void Fly()
        {
            _gunBulletMover.Enable();
        }

        public void SetStartPosition()
        {
        }

        private void SetIGameFactory(IGameFactory gameFactory) => _iGameFactory = gameFactory;

        private void SetStartSpeed() => _startSpeed = _staticData.Speed;
    }
}