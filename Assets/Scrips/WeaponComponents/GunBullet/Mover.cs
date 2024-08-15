using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using UnityEngine;

namespace Scripts.WeaponsComponents.GunBullet
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;

        private Quaternion _shootPointRotation;

        public void Construct(IGameFactory gameFactory)
        {
            SetShootPointRotation(gameFactory);
            Disable();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void StartMove()
        {
            Enable();
            SetRotation(_shootPointRotation);
        }

        private void SetRotation(Quaternion shootPoint) => transform.rotation = shootPoint;

        public void Enable() => enabled = true;

        public void Disable() => enabled = false;

        private void Move()
        {
            Debug.Log("Дописать здесь");

            transform.Translate(transform.forward * Speed());
        }

        private float Speed() => _bullet.StartSpeed * Time.deltaTime;

        private void SetShootPointRotation(IGameFactory gameFactory) => _shootPointRotation = gameFactory.Player.GetComponent<ShootPointSetter>().ShootPoint.transform.rotation;
    }
}