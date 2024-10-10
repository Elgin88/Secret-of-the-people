using Secret.Infrastructure.Factory;
using Secret.Weapons.Gun;
using UnityEngine;

namespace Secret.Weapons.GunBullet
{
    public class GunBulletMover : MonoBehaviour, IBulletMover, IBullet
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
            _isSetStartPosition = true;
            transform.position = _shootPointTransform.position;
        }
    }
}