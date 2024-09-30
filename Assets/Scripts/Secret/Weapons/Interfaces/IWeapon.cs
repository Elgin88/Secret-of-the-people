using UnityEngine;

namespace Secret.Weapons.Interfaces
{
    public interface IWeapon
    {
        public void Attack(Collider target, Transform shootPoint);

        public void Reload(IClip iClip);
    }
}