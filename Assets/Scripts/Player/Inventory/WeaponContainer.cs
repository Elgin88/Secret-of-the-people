using System;
using System.Collections.Generic;
using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Player.Inventory
{
    public class WeaponContainer : MonoBehaviour
    {
        private List<GameObject> _container = new List<GameObject>();
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            SetGameFactory(gameFactory);
        }

        public void AddGun()
        {
            _container.Add(_gameFactory.CreateGun());
        }

        public void AddGunClip(int clipCount)
        {
            for (int i = 0; i < clipCount; i++)
            {
                _container.Add(_gameFactory.CreateGunClip());
            }
        }

        private void SetGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;
    }
}