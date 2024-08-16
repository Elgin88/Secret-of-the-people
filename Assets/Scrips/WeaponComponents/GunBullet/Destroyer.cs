using UnityEngine;

namespace Scripts.Weapons.GunBullet
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private CollisionSetter _collision;

        private void Awake() => _collision.OnBulletEnter += OnBulletEnter;

        private void OnDestroy() => _collision.OnBulletEnter -= OnBulletEnter;

        private void OnBulletEnter() => Destroy(gameObject);
    }
}