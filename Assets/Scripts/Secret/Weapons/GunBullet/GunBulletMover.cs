using Secret.Infrastructure.Factory;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.GunBullet
{
    public class GunBulletMover : MonoBehaviour, IGunBulletMover
    {
        private IGameFactory _gameFactory;
        private Transform _shootPointTransform;
        private bool _isSetStartPosition = false;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _shootPointTransform = _gameFactory.PlayerShootPointTransform;
        }

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (!_isSetStartPosition)
            {
                SetStartPosition();
            }
        }

        public void StartFly()
        {
            enabled = true;
        }

        public void StopFly()
        {
            enabled = false;
        }

        private void SetStartPosition()
        {
            _isSetStartPosition = true;
            transform.position = _shootPointTransform.position;
        }
    }
}