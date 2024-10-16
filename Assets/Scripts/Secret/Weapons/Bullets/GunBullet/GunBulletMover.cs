using Secret.Infrastructure.Factory;
using Secret.StaticData;
using Secret.Weapons.Weapons.Gun;
using UnityEngine;

namespace Secret.Weapons.Bullets.GunBullet
{
    public class GunBulletMover : MonoBehaviour, IBulletMover, IGun
    {
        [SerializeField] private BulletStaticData _staticData;

        private IGameFactory _gameFactory;
        private IBulletMover _currentBulletMover;
        private Transform _shootPoint => _gameFactory.PlayerShootPoint;
        private bool _inStartPosition = false;

        public float MoveSpeed => _staticData.MoveSpeed;

        public IBulletMover CurrentBulletMover => _currentBulletMover;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;

            gameObject.SetActive(false);
        }

        private void Awake()
        {
            _currentBulletMover = GetComponent<IBulletMover>();
        }

        private void FixedUpdate()
        {
            if (!_inStartPosition)
            {
                SetStartPosition();
            }

            Debug.Log("Дописать движение пули");
        }

        public void StartMove() => enabled = true;

        public void StopMove() => enabled = false;

        private void SetStartPosition()
        {
            _inStartPosition = true;
            transform.position = _shootPoint.position;
        }
    }
}