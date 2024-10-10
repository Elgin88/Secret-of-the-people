using Secret.Infrastructure.Factory;
using UnityEngine;

namespace Secret.Weapons.Bullets.GunBullet
{
    public class GunBulletMover : MonoBehaviour, IBulletMover, IBullet
    {
        private IGameFactory _gameFactory;
        private Transform _shootPoint => _gameFactory.PlayerShootPoint;
        private bool _isStartPosition = false;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (!_isStartPosition)
            {
                SetStartPosition();
            }
        }

        public void StartMove()
        {
            Debug.Log("StartMove");
            enabled = true;
        }

        public void StopMove()
        {
            enabled = false;
        }

        private void SetStartPosition()
        {
            _isStartPosition = true;
            transform.position = _shootPoint.position;
        }
    }
}