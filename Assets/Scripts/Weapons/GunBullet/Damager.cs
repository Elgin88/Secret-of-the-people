using Enemy.Logic;
using StaticData;
using UnityEngine;

namespace Weapons.GunBullet
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private CollisionChecker _collisionSetter;
        [SerializeField] private BulletStaticData _staticData;

        private int _currentDamage => _staticData.Damage;

        private void Awake() => SubBulletEnter();

        private void OnDestroy() => UnsubBulletEnter();

        private void GiveDamage(Collider collider) => collider.GetComponent<IEnemyHealthChanger>().RemoveHealth(_currentDamage);

        private void SubBulletEnter() => _collisionSetter.BulletEnter += GiveDamage;

        private void UnsubBulletEnter() => _collisionSetter.BulletEnter -= GiveDamage;
    }
}