using System;
using Scripts.Interfaces;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons.GunBullet
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private CollisionSetter _collisionSetter;
        [SerializeField] private BulletStaticData _staticData;

        private int _currentDamage;

        private void Awake()
        {
            _currentDamage = _staticData.Damage;

            _collisionSetter.OnBulletEnter += GiveDamage;
        }

        private void GiveDamage(Collider collider)
        {
            collider.GetComponent<IHealth>().TakeDamage(_currentDamage);
        }

        private void OnDestroy()
        {
            _collisionSetter.OnBulletEnter -= GiveDamage;
        }
    }
}