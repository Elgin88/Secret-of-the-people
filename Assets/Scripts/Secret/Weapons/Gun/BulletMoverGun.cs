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
        }

        public void Enable()
        {
            enabled = true;
        }
    }
}