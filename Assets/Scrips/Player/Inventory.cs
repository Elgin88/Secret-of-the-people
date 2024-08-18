﻿using System.Collections.Generic;
using Scripts.CodeBase.Logic;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private ChooserWeapon _chooserWeapon;
        [SerializeField] private ObjectsCreator _objectsCreator;
        [SerializeField] private StartWeaponSetter _startObjectsSetter;

        private IGameFactory _gameFactory;
        private List<IWeapon> _weapons = new List<IWeapon>();
        private List<IClip> _clips = new List<IClip>();

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _objectsCreator.Construct(_gameFactory);
            _startObjectsSetter.Construct();
            _chooserWeapon.Construct();
        }

        public IWeapon GetGun()
        {
            foreach (IWeapon weapon in _weapons)
            {
                if (weapon.Name == StaticWeapon.Gun)
                {
                    return weapon;
                }
            }

            return null;
        }

        public IClip GetGunClip()
        {
            foreach (IClip clip in _clips)
            {
                if (clip.Name == StaticWeapon.GunClip)
                {
                    _clips.Remove(clip);

                    return clip;
                }
            }

            return null;
        }

        public void AddWeapon(IWeapon weapon)
        {
            _weapons.Add(weapon);
        }

        public void AddClip(IClip clip)
        {
            _clips.Add(clip);
        }
    }
}