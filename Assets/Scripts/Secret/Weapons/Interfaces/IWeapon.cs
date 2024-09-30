using UnityEngine;

namespace Secret.Weapons.Interfaces
{
    public interface IWeapon
    {
        public void Attack(Collider target, Transform shootPoint, IBullet bullet);

        public void Reload(IClip iclip);
    }
}