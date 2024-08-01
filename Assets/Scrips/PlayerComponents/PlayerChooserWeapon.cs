using System.Collections.Generic;
using Scripts.CodeBase.Logic;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserWeapon : MonoBehaviour
    {
        private IGameFactory _iGameFactory;
        private Weapon _startWeapon;
        private Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;

        private void Awake()
        {
            SetStartWeapon();
            SetCurrentWeapon();
        }

        public void Construct(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void SetStartWeapon() => _startWeapon = _iGameFactory.Gun.GetComponent<Weapon>();

        private void SetCurrentWeapon() => _currentWeapon = _startWeapon;
    }
}