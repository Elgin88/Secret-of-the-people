using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunBullet : MonoBehaviour, IBullet
    {
        [SerializeField] private GunBulletMover _gunBulletMover;

        public void Fly(Collider target)
        {
            throw new System.NotImplementedException();
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