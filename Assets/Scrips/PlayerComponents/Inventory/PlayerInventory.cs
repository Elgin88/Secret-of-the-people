using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using Scripts.Weapons;
using System;
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

        internal GameObject GetGunClip()
        {
            foreach (GameObject clip in _clips)
            {
                if (clip.GetComponent<GunClip>() != null)
                {
                    _clips.Remove(clip);
                    return clip;
                }
            }

            return null;
        }
    }
}