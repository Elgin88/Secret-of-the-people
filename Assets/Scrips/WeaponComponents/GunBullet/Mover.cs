using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using UnityEngine;

namespace Scripts.WeaponsComponents.GunBullet
{
    [RequireComponent(typeof(Bullet))]
    [RequireComponent(typeof(Destroyer))]

    public class Mover : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Destroyer _destroySetter;

        private NextTargetFinder _chooserTarget;
        private IGameFactory _gameFactory;
        private const float moveUpValue = 1.5f;
        private Vector3 _targetPosition;

        public void Construct(IGameFactory gameFactory)
        {
            SetGameFactory(gameFactory);
            SetChooserNearestTarget();
        }

        private void FixedUpdate()
        {
            Move();

            if (IsEndMove())
            {
                Destroy();
            }
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

        private void Destroy() => _destroySetter.Destroy();

        private bool IsEndMove() => transform.position == _targetPosition;

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Speed());
        }

        private void SetTargetPositon()
        {
            _targetPosition = new Vector3(_chooserTarget.CurrentTarget.transform.position.x, _chooserTarget.CurrentTarget.transform.position.y + moveUpValue, _chooserTarget.CurrentTarget.transform.position.z);
        }
    }
}