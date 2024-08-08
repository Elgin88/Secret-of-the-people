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
        private int _startClipsCount;

        private GameObject _gun;

        private void Awake()
        {
            SetStartClipsCount();
        }

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);
            CreateGun();
            AddGunToInventory();
            AddClipsToInventory();
            SetStartWeapon(GetGun());
        }

        private void AddClipsToInventory()
        {
            for (int i = 0; i < _startClipsCount; i++)
            {
                _clips.Add(GetClip());
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

        private void SetIGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void AddGunToInventory() => _weapons.Add(_gun);

        private void CreateGun() => _gun = _iGameFactory.CreateGun();

        private IWeapon GetGun() => _gun.GetComponent<IWeapon>();

        private void SetStartClipsCount() => _startClipsCount = _staticData.StartClipsCount;

        private GameObject GetClip() => _iGameFactory.CreateGunClip();

        private void SetStartWeapon(IWeapon weapon) => _playerChooserWeapon.SetCurrentWeapon(weapon);
    }
}