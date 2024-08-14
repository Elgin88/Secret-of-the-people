using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.WeaponsComponents
{
    public class GunBullet : MonoBehaviour, IBullet
    {
        [SerializeField] private BulletStaticData _staticData;
        [SerializeField] private GunBulletMover _mover;

        private IGameFactory _gameFactory;

        private float _startSpeed;

        public float StartSpeed => _startSpeed;

        public void Construct(IGameFactory gameFactory)
        {
            SetIGameFactory(gameFactory);
            SetStartSpeed();
        }

        public void Fly()
        {
            _mover.Enable();
        }

        public void SetStartPosition()
        {
        }

        private void SetIGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void SetStartSpeed() => _startSpeed = _staticData.Speed;
    }
}