using UnityEngine;

namespace Secret.Weapons.Interfaces
{
    public interface IBullet
    {
        public void Fly(Collider target);

        public void SetPosition(Vector3 position);

        public void SetRotation(Quaternion quaternion);
    }
}