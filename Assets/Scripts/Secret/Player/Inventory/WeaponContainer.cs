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

            Debug.Log("Добавить Gun and Clips через GameFactory");
        }

        public void AddClips(GameObject clip)
        {
            for (int i = 0; i < _clipCount; i++)
            {
                _clips.Add(clip);
            }
        }

        public void AddGun()
        {
            _weapons.Add(_gameFactory.CreateGun());
        }
    }
}