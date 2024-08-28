using System;
using UnityEngine;

namespace Weapons.GunBullet
{
    public class CollisionChecker : MonoBehaviour
    {
        public Action<Collider> BulletEnter;

        private void OnTriggerEnter(Collider collider)
        {
            BulletEnter.Invoke(collider);
        }
    }
}