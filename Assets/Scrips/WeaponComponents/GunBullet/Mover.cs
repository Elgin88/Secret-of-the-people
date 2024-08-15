using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using UnityEngine;

namespace Scripts.WeaponsComponents.GunBullet
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;

        private NextTargetFinder _chooserTarget;
        private IGameFactory _gameFactory;
        private const float moveUpValue = 1.5f;
        private Vector3 _targetPosition;

        public void Construct(IGameFactory gameFactory)
        {
            SetGameFactory(gameFactory);
            SetChooserNearestTarget();
            Disable();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void StartMove()
        {
            Enable();
            SetRotation();
            SetTargetPositon();
        }

        public void Enable() => enabled = true;

        public void Disable() => enabled = false;

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Speed());
        }

        private float Speed() => _bullet.StartSpeed * Time.deltaTime;

        private Quaternion SetShootPointRotation() => _gameFactory.Player.GetComponent<ShootPointSetter>().ShootPoint.transform.rotation;

        private void SetGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void SetRotation() => transform.rotation = SetShootPointRotation();

        private void SetChooserNearestTarget() => _chooserTarget = _gameFactory.Player.GetComponent<NextTargetFinder>();

        private void SetTargetPositon()
        {
            _targetPosition = new Vector3(_chooserTarget.CurrentTarget.transform.position.x, _chooserTarget.CurrentTarget.transform.position.y + moveUpValue, _chooserTarget.CurrentTarget.transform.position.z);
        }
    }
}