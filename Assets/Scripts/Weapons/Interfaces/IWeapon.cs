using UnityEngine;

namespace Weapons.Interfaces
{
    public interface IWeapon
    {
        public void Attack(Collider target);
    }
}