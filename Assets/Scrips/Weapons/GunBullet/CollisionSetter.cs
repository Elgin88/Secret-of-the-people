using System;
using UnityEngine;

namespace Scripts.Weapons.GunBullet
{
    public class CollisionSetter : MonoBehaviour
    {
        public Action<Collider> OnBulletEnter;

        private void OnTriggerEnter(Collider collider)
        {
            OnBulletEnter.Invoke(collider);
        }
    }
}