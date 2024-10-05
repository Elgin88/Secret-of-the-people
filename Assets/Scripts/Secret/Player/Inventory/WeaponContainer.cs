using System;
using System.Collections.Generic;
using Secret.Infrastructure.Services.Factory;
using Secret.Weapons.StaticData;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class WeaponContainer : MonoBehaviour
    {
        private List<GameObject> _weapons = new List<GameObject>();
        private List<GameObject> _clips = new List<GameObject>();
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void AddClip()
        {
            _clips.Add(_gameFactory.CreateGunClip());
        }

        public void AddGun()
        {
            _weapons.Add(_gameFactory.CreateGun());
        }
    }
}