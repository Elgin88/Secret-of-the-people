using Scripts.CodeBase.Logic;
using Scripts.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;

        private List<GameObject> _weapons = new List<GameObject>();
        private IGameFactory _iGameFactory;

        private GameObject _gun;

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);
            CreateGun();
            AddGun();
            SetStartWeapon(_gun.GetComponent<IWeapon>());
        }

        private void SetStartWeapon(IWeapon weapon) => _playerChooserWeapon.SetCurrentWeapon(weapon);

        public GameObject GetWeaponGun()
        {
            foreach (var weapon in _weapons)
            {
                if (weapon.GetComponent<Gun>() != null)
                {
                    return weapon;
                }
            }

            return null;
        }

        private void SetIGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void AddGun() => _weapons.Add(_gun);

        private void CreateGun() => _gun = _iGameFactory.CreateGun();
    }
}