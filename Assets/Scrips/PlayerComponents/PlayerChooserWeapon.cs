using System.Collections.Generic;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserWeapon : MonoBehaviour
    {
        private List<Weapon> _weapons;
        private Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;
    }
}