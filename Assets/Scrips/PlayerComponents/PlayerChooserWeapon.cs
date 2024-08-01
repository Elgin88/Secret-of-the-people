using System.Collections.Generic;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserWeapon : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _weapons;

        private Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;

        private void Awake()
        {
            foreach (GameObject weapon in _weapons)
            {
                weapon.GetComponent<Weapon>().Construct();
            }

            _currentWeapon = _weapons[0].GetComponent<Weapon>();
        }
    }
}