using System;
using System.Collections.Generic;
using Secret.Infrastructure.Factory;
using Secret.Weapons.Clips;
using Secret.Weapons.Weapons;
using Secret.Weapons.Weapons.Gun;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class Container : MonoBehaviour, IContainer
    {
        public List<GameObject> _weapons = new List<GameObject>();
        public List<GameObject> _clips = new List<GameObject>();
        public IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void AddGun()
        {
            _weapons.Add(_gameFactory.CreateGun());
        }

        public void AddGunClips()
        {
            _clips.Add(_gameFactory.CreateGunClip());
        }

        public void AddBulletsInAllClips()
        {
            foreach (GameObject clip in _clips)
            {
                clip.GetComponent<IClip>().ClipContainer.Fill();
            }
        }

        public IWeapon GetGun()
        {
            foreach (GameObject weapon in _weapons)
            {
                if (weapon.GetComponent<IGun>() != null)
                {
                    return weapon.GetComponent<IWeapon>();
                }
            }

            return null;
        }

        public GameObject GetClip()
        {
            GameObject clip = _clips[0];

            return clip;
        }
    }
}