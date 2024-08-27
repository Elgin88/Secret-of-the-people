using Scripts.Weapons;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Inventory))]
    public class ChooserWeapon : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;

        public IWeapon CurrentWeapon { get; private set; }

        public void Construct()
        {
            CurrentWeapon = _inventory.GetGun();
        }
    }
}