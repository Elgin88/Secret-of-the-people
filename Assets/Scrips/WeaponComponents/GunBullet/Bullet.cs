using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.WeaponsComponents.GunBullet
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private BulletStaticData _staticData;
        [SerializeField] private Mover _mover;

        private IGameFactory _gameFactory;

        private float _startSpeed;

        public float StartSpeed => _startSpeed;

        public void Construct(IGameFactory gameFactory)
        {
            SetIGameFactory(gameFactory);
            _mover.Construct(gameFactory);
        }

        private void Awake()
        {
            SetStartSpeed();
        }

        public void Move()
        {
            SetStartPosition();
            _mover.StartMove();
        }

        private void SetStartPosition() => transform.position = _gameFactory.Player.GetComponent<ShootPointSetter>().ShootPoint.transform.position;

        private void SetIGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void SetStartSpeed() => _startSpeed = _staticData.Speed;
    }
}