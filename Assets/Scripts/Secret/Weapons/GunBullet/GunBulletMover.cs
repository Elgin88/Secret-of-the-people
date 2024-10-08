using Secret.Infrastructure.Factory;
using Secret.Player.Logic;
using UnityEngine;

namespace Secret.Weapons.GunBullet
{
    public class GunBulletMover : MonoBehaviour
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

            Debug.Log("Move");
            Debug.Log(_shootPointTransform.position);
        }

        public void StartMove()
        {
            enabled = true;
        }

        public void StopMove()
        {
            enabled = false;
        }

        private void SetStartPosition()
        {
            _isSetStartPosition = true;
        }
    }
}