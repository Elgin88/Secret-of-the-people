﻿using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using Scripts.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;
        [SerializeField] private PlayerStaticData _staticData;

        private IGameFactory _iGameFactory;
        private List<GameObject> _weapons = new List<GameObject>();
        private List<GameObject> _clips = new List<GameObject>();
        private int _clipCount;

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);
            SetClipCount();
            AddWeaponToInventory(CreateGun());
            AddClipsToInventory(_clipCount);
        }

        private GameObject CreateGun() => _iGameFactory.CreateGun();

        private GameObject CreateClip() => _iGameFactory.CreateGunClip();

        private void SetIGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void AddWeaponToInventory(GameObject weapon) => _weapons.Add(weapon);

        private void SetClipCount() => _clipCount = _staticData.StartClipsCount;

        private void AddClipsToInventory(int clipCount)
        {
            for (int i = 0; i < clipCount; i++)
            {
                _clips.Add(CreateClip());
            }
        }

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
    }
}