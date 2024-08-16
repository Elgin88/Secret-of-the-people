using System;
using UnityEngine;

namespace Scripts.Weapons.GunBullet
{
    public class CollisionSetter : MonoBehaviour
    {
        public Action OnBulletEnter;

        private void OnTriggerEnter(Collider other)
        {
            OnBulletEnter.Invoke();
        }
    }
}