using System.Collections.Generic;
using Infrastructure.Services.Factory;
using UnityEngine;
using Weapons.Gun;
using Weapons.Interfaces;

namespace Player.Inventory
{
    public class WeaponContainer : MonoBehaviour
    {
        private List<GameObject> _weapons = new List<GameObject>();
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            SetGameFactory(gameFactory);
        }

        public IWeapon GetGun()
        {
            IWeapon iWeapon = null;

            foreach (GameObject weapon in _weapons)
            {
                if (weapon.GetComponent<Gun>())
                {
                    iWeapon = weapon.GetComponent<IWeapon>();
                }
            }

            return iWeapon;
        }

        public void AddGun()
        {
            _weapons.Add(_gameFactory.CreateGun());
        }

        public void AddFullGunClip(int clipCount)
        {
            for (int i = 0; i < clipCount; i++)
            {
                GameObject gunClip = _gameFactory.CreateGunClip();

                gunClip.GetComponent<IClip>().Fill();

                _weapons.Add(gunClip);
            }
        }

        private void SetGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;
    }
}