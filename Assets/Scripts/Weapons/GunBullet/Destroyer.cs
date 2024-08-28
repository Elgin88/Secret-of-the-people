using UnityEngine;

namespace Weapons.GunBullet
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private CollisionChecker _collision;

        private void Awake() => _collision.BulletEnter += OnBulletEnter;

        private void OnDestroy() => _collision.BulletEnter -= OnBulletEnter;

        public void OnBulletEnter(Collider collider) => Destroy();

        public void Destroy() => Destroy(gameObject);

    }
}