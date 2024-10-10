﻿using Secret.Infrastructure.Factory;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunContainer : MonoBehaviour, IWeapon, IGun, IWeaponContainer
    {
        private IGameFactory _gameFactory;

        public GameObject CurrentGunClip { get; private set; }

        public IClip ICurrentClip { get; set; }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void AddClipFromInventory()
        {
            CurrentGunClip = _gameFactory.PlayerWeaponContainer.GetGunClipFromInventory();


            ICurrentClip = CurrentGunClip.GetComponent<IClip>();
        }

        public IBulletMover GetTopIBulletMover()
        {
            return CurrentGunClip.GetComponent<IBulletMover>();
        }
    }
}