using UnityEngine;

namespace Secret.Weapons.Interfaces
{
    public interface IWeapon
    {
        public void Attack(Collider target, Transform shootPoint);
    }
}