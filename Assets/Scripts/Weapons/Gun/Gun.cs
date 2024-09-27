using UnityEngine;
using Weapons.Interfaces;

namespace Weapons.Gun
{
    public class Gun : MonoBehaviour, IWeapon
    {
        public void Attack(Collider target)
        {
        }
    }
}