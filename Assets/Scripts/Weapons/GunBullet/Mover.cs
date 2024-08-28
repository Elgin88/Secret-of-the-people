using Infrastructure.Services.Factory;
using Player;
using Player.Logic;
using UnityEngine;

namespace Weapons.GunBullet
{
    [RequireComponent(typeof(CollisionChecker))]
    [RequireComponent(typeof(Destroyer))]
    [RequireComponent(typeof(Bullet))]

    public class Mover : MonoBehaviour
    {
        [SerializeField] private CollisionChecker _collisionSetter;
        [SerializeField] private Destroyer _destroyer;
        [SerializeField] private Bullet _bullet;

        private TargetFinder _chooserTarget;
        private IGameFactory _gameFactory;
        private const float _moveUpValue = 1.5f;
        private Vector3 _targetPosition;

        public void Construct(IGameFactory gameFactory)
        {
            SetGameFactory(gameFactory);
            SetChooserNearestTarget();
        }

        private void FixedUpdate()
        {
            Move();
            TryDestroy();
        }

        public void StartMove()
        {
            EnableGameObject();
            SetRotation();
            SetTargetPositon();
        }

        private void EnableGameObject() => gameObject.SetActive(true);

        private float Speed() => _bullet.StartSpeed * Time.deltaTime;

        private void SetGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void SetRotation() => transform.rotation = _gameFactory.Player.GetComponent<ShootPointSetter>().ShootPoint.transform.rotation;

        private void SetChooserNearestTarget() => _chooserTarget = _gameFactory.Player.GetComponent<TargetFinder>();

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Speed());
        }

        private void SetTargetPositon()
        {
            _targetPosition = new Vector3(_chooserTarget.CurrentTarget.transform.position.x, _chooserTarget.CurrentTarget.transform.position.y + _moveUpValue, _chooserTarget.CurrentTarget.transform.position.z);
        }

        private void TryDestroy()
        {
            if (transform.position == _targetPosition)
            {
                _destroyer.Destroy();
            }
        }
    }
}