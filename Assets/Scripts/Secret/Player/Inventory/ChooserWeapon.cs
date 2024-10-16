using Secret.Weapons.Weapons;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class ChooserWeapon : MonoBehaviour
    {
        private Container _container;

        public IWeapon CurrentWeapon;

        public void Construct()
        {
            SetCurrentWeapon();
        }

        private void Awake()
        {
            _container = GetComponent<Container>();
        }

        private void SetCurrentWeapon()
        {
            Debug.Log("Дописать выбор оружия");
        }
    }
}