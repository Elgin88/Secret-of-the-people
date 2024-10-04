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
        private const int _clipCount = 2;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;

            AddGun();
            AddGunClips();
            FillClips();
        }

        private void FillClips()
        {
            Debug.Log("Сделать заполнение пулей");
        }

        private void AddGun() => _weapons.Add(_gameFactory.CreateGun());

        private void AddGunClips()
        {
            for (int i = 0; i < _clipCount; i++)
            {
                _clips.Add(_gameFactory.CreateGunClip());
            }
        }
    }
}