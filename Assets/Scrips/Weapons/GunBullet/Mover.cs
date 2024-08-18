using Scripts.CodeBase.Logic;
using Scripts.Player;
using UnityEngine;

namespace Scripts.Weapons.GunBullet
{
    [RequireComponent(typeof(CollisionSetter))]
    [RequireComponent(typeof(Destroyer))]
    [RequireComponent(typeof(Bullet))]

    public class Mover : MonoBehaviour
    {
        [SerializeField] private CollisionSetter _collisionSetter;
        [SerializeField] private Destroyer _destroyer;
        [SerializeField] private Bullet _bullet;

        private NextTargetFinder _chooserTarget;
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

        private void SetChooserNearestTarget() => _chooserTarget = _gameFactory.Player.GetComponent<NextTargetFinder>();

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