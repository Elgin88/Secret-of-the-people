using System;
using System.Collections.Generic;
using Secret.Infrastructure.Services.Factory;
using Secret.Weapons.Gun;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Player.Inventory
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
                if (weapon.GetComponent<GunAttacker>())
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

        public IClip GetClip()
        {
            throw new NotImplementedException();
        }
    }
}