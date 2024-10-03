using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class BulletGun : MonoBehaviour, IBullet
    {
        [SerializeField] private BulletMoverGun _gunBulletMover;

        public void Fly(Collider target)
        {
            _gunBulletMover.Enable();
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Quaternion quaternion)
        {
            transform.rotation = quaternion;
        }
    }
}