using System;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class BulletMoverGun : MonoBehaviour
    {
        private void Awake()
        {
            enabled = false;
        }

        private void FixedUpdate()
        {
            Debug.Log("Add BulletMoverGun");
        }

        public void Enable()
        {
            enabled = true;
        }
    }
}