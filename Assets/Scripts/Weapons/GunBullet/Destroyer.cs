using UnityEngine;

namespace Weapons.GunBullet
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private CollisionChecker _collision;

        private void Awake() => _collision.OnBulletEnter += OnBulletEnter;

        private void OnDestroy() => _collision.OnBulletEnter -= OnBulletEnter;

        public void OnBulletEnter(Collider collider) => Destroy();

        public void Destroy() => Destroy(gameObject);

    }
}