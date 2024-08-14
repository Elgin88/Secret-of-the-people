using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using Scripts.Weapons;
using System;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerInventoryObjectsCreator))]
    [RequireComponent(typeof(PlayerInventory))]

    public class PlayerInventotyStartWeaponSetter : MonoBehaviour
    {
        [SerializeField] private PlayerInventoryObjectsCreator _objectCreator;
        [SerializeField] private PlayerInventory _inventory;
        [SerializeField] private PlayerStaticData _staticData;

        private int _startGunClipCount;

        public void Construct()
        {
            SetStartClipCount();
            AddGunInInventory();
            AddGunClipsInInventory();
            AddClipInGun();
        }

        private void AddClipInGun()
        {
            IClip clip = _inventory.GetGunClip();
            _inventory.GetGun().SetClip(clip);
        }

        private void AddGunInInventory()
        {
            _inventory.AddWeapon(_objectCreator.GetGun());
        }

        private void AddGunClipsInInventory()
        {
            for (int i = 0; i < _startGunClipCount; i++)
            {
                _inventory.AddClip(_objectCreator.GetGunClip());
            }
        }

        private void SetStartClipCount() => _startGunClipCount = _staticData.StartGunClipsCount;
    }
}