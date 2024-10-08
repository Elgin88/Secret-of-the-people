using Secret.Infrastructure.Factory;
using Secret.Player.Logic;
using UnityEngine;

namespace Secret.Weapons.GunBullet
{
    public class GunBulletMover : MonoBehaviour
    {
        [SerializeField] private GunBullet _gunBullet;

        private IGameFactory _gameFactory;
        private Transform _shootPointTransform;
        private bool _isSetStartPosition = false;

        public void Construct(IGameFactory gameFactory)
        {
            SetGameFactory(gameFactory);
            SetShootPointTransform();
        }

        private void FixedUpdate()
        {
            if (!_isSetStartPosition)
            {
                SetStartPosition();
            }
        }

        public void StartMove()
        {
            enabled = true;
        }

        public void StopMove()
        {
            enabled = false;
        }

        private void SetShootPointTransform() => _shootPointTransform = _gameFactory.Player.GetComponent<ShootPointSetter>().ShootPoint.transform;
        private void SetGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void SetStartPosition()
        {
            _gunBullet.SetPosition(_shootPointTransform.position);
            _isSetStartPosition = true;
        }
    }
}