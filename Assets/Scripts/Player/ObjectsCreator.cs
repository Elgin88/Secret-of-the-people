﻿using Infrastructure.Services.Factory;
using UnityEngine;
using Weapons.Interfaces;

namespace Player
{
    public class ObjectsCreator : MonoBehaviour
    {
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        public IWeapon GetGun() => _gameFactory.CreateGun().GetComponent<IWeapon>();

        public IClip GetGunClip() => _gameFactory.CreateGunClip().GetComponent<IClip>();

        public IBullet GetGunBullet() => _gameFactory.CreateGunBullet().GetComponent<IBullet>();
    }
}